using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progice2
{
    public static class InputValidator
    {
        public static bool ValidateQuantity(string input)
        {
            if (int.TryParse(input, out int quantity) && quantity >= 0)
            {
                return true;
            }
            MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public static bool ValidatePrice(string input)
        {
            if (decimal.TryParse(input, out decimal price) && price >= 0)
            {
                return true;
            }
            MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}
