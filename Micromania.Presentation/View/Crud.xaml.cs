using Micromania.Domain;
using Micromania.Infrastructure;
using Micromania.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Micromania.Presentation.View
{
    /// <summary>
    /// Interaction logic for Crud.xaml
    /// </summary>
    public partial class Crud : Window
    {
        #region declarations
        SessionFactory sessionFactory;
        #endregion

        #region methods
        private void load_records(string sFilter = "")
        {
                    string h_stmt = "FROM Customers";

                    if (sFilter != "")
                    {
                        h_stmt += " WHERE " + sFilter;
                    }
                    IQuery query = session.CreateQuery(h_stmt);

                    IList<Customers> customersList = query.List<Customers>();

                    dgvListCustomers.DataSource = customersList;

                    lblStatistics.Text = "Total records returned: " + customersList.Count;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void load_customer_details(int client_id)
        {
                        IQuery query = session.CreateQuery("FROM Customers WHERE customer_id = " + customer_id);

                        Client client = query.List<Client>()[0];

                        txtCustomerId.Text = customer.customer_id.ToString();
                        txtName.Text = customer.name;
                        txtEmail.Text = customer.email;
                        txtContactPerson.Text = customer.contact_person;
                        txtContactNumber.Text = customer.contact_number;
                        txtPostalAddress.Text = customer.postal_address;
                        txtPhysicalAddress.Text = customer.physical_address;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Exception Msg");
                    }
                }
            }
        }

        #endregion

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            load_records();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string sFilterValue = string.Empty;
            string sField = cboFilter.Text;
            string sCriteria = cboCriteria.Text;
            string sValue = txtValue.Text;

            switch (sCriteria)
            {
                case "Equals":
                    sFilterValue = sField + " = '" + sValue + "'";
                    break;

                case "Begins with":
                    sFilterValue = sField + " LIKE '" + sValue + "%'";
                    break;

                case "Contains":
                    sFilterValue = sField + " LIKE '%" + sValue + "%'";
                    break;

                case "Ends with":
                    sFilterValue = sField + " LIKE '%" + sValue + "'";
                    break;
            }

            //data.Add(sFilterValue, sValue);

            load_records(sFilterValue);
        }

        private void dgvListCustomers_Click(object sender, EventArgs e)


        public Crud()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
