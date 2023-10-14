using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Desktop.Model;
using Desktop.Repository;

namespace Desktop.Window
{
    public partial class MainWindow
    {
        private static bool isCheked;
        private ObservableCollection<CategoryModel> TasksCategory { get; set; }
        private List<SolidColorBrush> Colors { get; set; }
        
        public MainWindow(string name = "")
        {
            InitializeComponent();
            

            Colors = new List<SolidColorBrush>
            {
                new SolidColorBrush(System.Windows.Media.Colors.Black),
                new SolidColorBrush(System.Windows.Media.Colors.Black),
                new SolidColorBrush(System.Windows.Media.Colors.Black),
                new SolidColorBrush(System.Windows.Media.Colors.Black),
            };

            
            TasksCategory = new ObservableCollection<CategoryModel>
            {
                new CategoryModel {Title = "Работа", TitleColor = Colors[0]},
                new CategoryModel {Title = "Учеба", TitleColor = Colors[1]},
                new CategoryModel {Title = "Отдых", TitleColor = Colors[2]},
                new CategoryModel {Title = "Дом", TitleColor = Colors[3]},
            };

            TaskCategoryListBox.ItemsSource = TasksCategory;
            TasksListBox.ItemsSource = TasksRepository.GetTasksIsChecked(isCheked);
        }

        private void AddTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new CreateWindow();
            window.Show();
            Hide();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel) TasksListBox.SelectedItem;
            TasksRepository.DeleteTask(task);
        }

        private void TasksListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task = (TaskModel) TasksListBox.SelectedItem;

            DetailDescriptionBlock.Visibility = Visibility.Visible;

            if (task != null)
            {
                TitleTextBlock.Text = task.Title;
                ContentTextBlock.Text = task.Content;
                TimeTextBlock.Text = task.Time;
                DateTextBlock.Text = task.Date;
            }
            else
            {
                DetailDescriptionBlock.Visibility = Visibility.Hidden;
            }
        }

        private void DoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel) TasksListBox.SelectedItem;
            task.IsChecked = true;
        }

        private void TasksConditionTextBlock_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isCheked = false;
            TasksListBox.ItemsSource = TasksRepository.GetTasksIsChecked(isCheked);
        }

        private void HistoryConditionTextBlock_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isCheked = true;
            TasksListBox.ItemsSource = TasksRepository.GetTasksIsChecked(isCheked);
        }
        
        private void TaskListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}