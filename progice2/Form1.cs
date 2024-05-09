using progice2;
using System;
using System.Windows.Forms;

namespace progice2
{
    public partial class MainForm : Form
    {
        private GroceryStore groceryStore;

        public MainForm()
        {
            InitializeComponent();
            groceryStore = new GroceryStore();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get user input
            string name = txtName.Text;
            string priceText = txtPrice.Text;
            string quantityText = txtQuantity.Text;
            string category = cboCategory.SelectedItem.ToString();

            // Validate input
            if (!InputValidator.ValidatePrice(priceText) || !InputValidator.ValidateQuantity(quantityText))
                return;

            decimal price = decimal.Parse(priceText);
            int quantity = int.Parse(quantityText);

            // Create inventory item
            InventoryItem item = new InventoryItem
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Category = category
            };

            // Add item to inventory
            groceryStore.Inventory.AddItem(item);

            // Display updated inventory
            groceryStore.Inventory.DisplayInventory(listBoxInventory);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Get selected item from the ListBox
            if (listBoxInventory.SelectedItem != null)
            {
                string selectedItem = listBoxInventory.SelectedItem.ToString();
                string[] parts = selectedItem.Split(',');
                string name = parts[0].Trim().Substring(2); // Trim and remove leading '-'
                string category = cboCategory.SelectedItem.ToString();

                // Find and remove the item from inventory
                InventoryItem itemToRemove = null;
                foreach (var item in groceryStore.Inventory.GetItemsByCategory(category))
                {
                    if (item.Name == name)
                    {
                        itemToRemove = item;
                        break;
                    }
                }

                if (itemToRemove != null)
                {
                    groceryStore.Inventory.RemoveItem(itemToRemove);
                    // Display updated inventory
                    groceryStore.Inventory.DisplayInventory(listBoxInventory);
                }
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cboCategory.SelectedItem.ToString();
            groceryStore.Inventory.DisplayInventory(listBoxInventory, selectedCategory);
        }
    }
}
