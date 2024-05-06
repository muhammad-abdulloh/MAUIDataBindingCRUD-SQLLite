using MAUIDataBindingCRUD.Models;
using MAUIDataBindingCRUD.Services;

namespace MAUIDataBindingCRUD
{
    public partial class MainPage : ContentPage
    {
        private readonly CustomerDBService _dbService;
        private int _editCustomerId;
        // dependency injection
        public MainPage(CustomerDBService customerDBService)
        {
            InitializeComponent();
            _dbService = customerDBService;

            Task.Run( async () => listView.ItemsSource = await _dbService.GetCustomers());

        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if(_editCustomerId == 0)
            {
                await _dbService.Insert(new Customer
                {
                    CustomerName = nameEntryField.Text,
                    Mobile = mobileEntryField.Text,
                    Email = emailEntryField.Text
                });
            }else
            {
                // edit
                await _dbService.Update(new Customer
                {
                    Id = _editCustomerId,
                    CustomerName = nameEntryField.Text,
                    Mobile = mobileEntryField.Text,
                    Email = emailEntryField.Text
                });

                _editCustomerId = 0;
            }

            nameEntryField.Text = string.Empty;
            mobileEntryField.Text = string.Empty;
            emailEntryField.Text = string.Empty;

            listView.ItemsSource = await _dbService.GetCustomers();
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var customer = (Customer)e.Item;

            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch(action)
            {
                case "Edit":
                    _editCustomerId = customer.Id;
                    nameEntryField.Text = customer.CustomerName;
                    emailEntryField.Text = customer.Email;
                    mobileEntryField.Text = customer.Mobile;
                    break;
                case "Delete":
                    await _dbService.Delete(customer);
                    listView.ItemsSource = await _dbService.GetCustomers();

                    break;
            }

        }
    }

}
