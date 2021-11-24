using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HackerRankChalenges.Challanges
{
    public class ChalengeParameter
    {
        public string Label { get; set; }
        public string DefaultValue { get; set; }


    }
    public abstract class Chalange : UserControl
    {
        protected string url;
        protected string name;
        protected List<ChalengeParameter> ChalangeParameters;
        private List<TextBox> ParametersTextboxes = new List<TextBox>();

        public Chalange()
        {
            this.SetParameters();
            this.BuildUserControl();
        }

        private void BuildUserControl()
        {
            Grid MainGrid = new Grid();
            MainGrid.RowDefinitions.Add(new RowDefinition());
            MainGrid.RowDefinitions.Add(new RowDefinition());
            Grid parameterGrid = BuildParameterGrid();

            AddElementToGrid(MainGrid, parameterGrid, 0, 0);


            //Button
            Button actionButton = new Button
            {
                Content = name,
                Padding = new System.Windows.Thickness(10, 5, 10, 5),

            };
            actionButton.Click += ActionButton_Click;



            AddElementToGrid(MainGrid, actionButton, 1, 0);


            this.Content = MainGrid;
        }

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            string[] prm = this.ParametersTextboxes.Select(txt => txt.Text).ToArray();
            MessageBox.Show($"result: {this.Run(prm)}");

        }


        private Grid BuildParameterGrid()
        {
            Grid parameterGrid = new Grid();
            //Add Columns
            parameterGrid.ColumnDefinitions.Add(new ColumnDefinition());
            parameterGrid.ColumnDefinitions.Add(new ColumnDefinition());


            for (int i = 0; i < ChalangeParameters.Count; i++)
            {
                var parameter = ChalangeParameters[i];
                parameterGrid.RowDefinitions.Add(new RowDefinition());
                //Label
                Label parameterLabel = new Label()
                {
                    Content = parameter.Label,
                    Margin = new System.Windows.Thickness(0, 0, 5, 0)
                };
                AddElementToGrid(parameterGrid, parameterLabel, i, 0);

                //TextBox
                TextBox parameterTextBox = new TextBox()
                {
                    MinHeight = 20,
                    MinWidth = 150,
                    Text = parameter.DefaultValue
                };

                AddElementToGrid(parameterGrid, parameterTextBox, i, 1);

                ParametersTextboxes.Add(parameterTextBox);

            }

            return parameterGrid;
        }

        private static void AddElementToGrid(Grid parameterGrid, UIElement parameterLabel, int row, int column)
        {
            parameterGrid.Children.Add(parameterLabel);
            Grid.SetRow(parameterLabel, row);
            Grid.SetColumn(parameterLabel, column);
        }

        public abstract string Run(string[] parameters);

        public abstract void SetParameters();
    }
}

