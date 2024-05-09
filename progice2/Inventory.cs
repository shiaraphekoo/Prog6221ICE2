using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progice2
{
    public class Inventory
    {
        private Dictionary<string, List<InventoryItem>> itemsByCategory;

        public Inventory()
        {
            itemsByCategory = new Dictionary<string, List<InventoryItem>>();
        }

        public void AddItem(InventoryItem item)
        {
            if (!itemsByCategory.ContainsKey(item.Category))
            {
                itemsByCategory[item.Category] = new List<InventoryItem>();
            }

            itemsByCategory[item.Category].Add(item);
        }

        public void RemoveItem(InventoryItem item)
        {
            if (itemsByCategory.ContainsKey(item.Category))
            {
                itemsByCategory[item.Category].Remove(item);
            }
        }

        public void DisplayInventory(ListBox listBox, string selectedCategory)
        {
            listBox.Items.Clear();
            foreach (var category in itemsByCategory)
            {
                listBox.Items.Add(category.Key + ":");
                foreach (var item in category.Value)
                {
                    listBox.Items.Add($" - {item.Name}, {item.Quantity}, ${item.Price}");
                }
            }
        }

        internal IEnumerable<object> GetItemsByCategory(string category)
        {
            throw new NotImplementedException();
        }
    }
}
