using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace popr.UCs
{
    /// <summary>
    /// Логика взаимодействия для AgentListUC.xaml
    /// </summary>
    public partial class AgentListUC : UserControl
    {
        public AgentListUC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable agentDataTable;
            agentDataTable = Class.SQLClass.returnDT("SELECT Agent.ID, Agent.Title, AgentType.Title, Agent.Address, Agent.INN, Agent.KPP, Agent.DirectorName, Agent.Phone, Agent.Email, Agent.Logo, Agent.Priority FROM Agent JOIN AgentType ON Agent.AgentTypeID = AgentType.ID");

            for(int i = 0; i < 10; i++)
            {
                //нужен try-catch

                InitAgent(AgentList, agentDataTable.Rows[i].ItemArray[2].ToString(), agentDataTable.Rows[i].ItemArray[1].ToString(), "15", agentDataTable.Rows[i].ItemArray[7].ToString(), agentDataTable.Rows[i].ItemArray[10].ToString(), "20", agentDataTable.Rows[i].ItemArray[9].ToString());
            }
            //InitAgent(AgentList, "Тип", "Название", "15", "+7 800 555 35 35", "10", "20", "фото");
            //InitAgent(AgentList, "Тип", "Название", "15", "+7 800 555 35 35", "10", "20", "фото");
            //InitAgent(AgentList, "Тип", "Название", "15", "+7 800 555 35 35", "10", "20", "фото");
        }

        private void InitAgent(StackPanel parentSP, string type, string name, string count, string phone, string priority, string discount, string photo)
        {
            Label typeAndNameTB = new Label();
            typeAndNameTB.Content = String.Format(type + " | " + name);

            Label countTB = new Label();
            countTB.Content = String.Format(count + " продаж за год");

            Label phoneTB = new Label();
            phoneTB.Content = phone;

            Label priorityTB = new Label();
            priorityTB.Content = String.Format("Приоритетность: " + priority);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(typeAndNameTB);
            stackPanel.Children.Add(countTB);
            stackPanel.Children.Add(phoneTB);
            stackPanel.Children.Add(priorityTB);

            Image agentImage = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri("../Assets/picture.PNG", UriKind.Relative);
            bi3.EndInit();
            agentImage.Height = 100;
            agentImage.Stretch = Stretch.Fill;
            agentImage.Source = bi3;

            Label discountTB = new Label();
            discountTB.Content = String.Format(discount + "%");
            discountTB.FontSize = 30;

            StackPanel agentCart = new StackPanel();
            agentCart.Orientation = Orientation.Horizontal;
            agentCart.Children.Add(agentImage);
            agentCart.Children.Add(stackPanel);
            agentCart.Children.Add(discountTB);
            agentCart.Margin = new Thickness(10);

            Border agentBorder = new Border();
            agentBorder.Child = agentCart;
            agentBorder.Width = mainSpace.Width;
            agentBorder.BorderBrush = Brushes.Black;
            agentBorder.BorderThickness = new Thickness(2);
            agentBorder.Margin = new Thickness(10);

            parentSP.Children.Add(agentBorder);
        }
    }
}
