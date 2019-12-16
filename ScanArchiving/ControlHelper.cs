using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace ScanArchiving
{
    public static class ControlHelper
    {
        public static string GetSql(string sql, ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                switch (c.GetType().Name)
                {
                    case "Button":
                        break;
                    case "Label":
                        break;
                    case "TextBox":
                        TextBox textBox = (TextBox)c;
                        if (!string.IsNullOrEmpty(textBox.Text))
                            sql += " And " + textBox.Name + " Like '%" + textBox.Text + "%'";
                        break;
                    case "ComboBox":
                        ComboBox comboBox = (ComboBox)c;
                        if (!string.IsNullOrEmpty(comboBox.Text))
                            sql += " And " + comboBox.Name + "=" + comboBox.Text;
                        break;
                    case "DateTimePicker":
                        DateTimePicker dateTimePicker = (DateTimePicker)c;
                        if (!String.IsNullOrWhiteSpace(dateTimePicker.Text))
                            sql += " And " + dateTimePicker.Name + "='" + dateTimePicker.Value.ToShortDateString() + "'";
                        break;
                }
            }
            return sql;
        }

        public static bool IpFilter(string ip)
        {
            return Regex.IsMatch(ip, @"^(([1-9]\d?)|(1\d{2})|(2[01]\d)|(22[0-3]))(\.((1?\d\d?)|(2[04]/d)|(25[0-5]))){3}$");
        }  
    } 
}
