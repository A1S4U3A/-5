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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ПР5
{
    public partial class MainWindow : Window
    {
        private List<string> strings;// Поле для хранения списка строк

        public MainWindow()// Конструктор
        {
            InitializeComponent();// Инициализация компонентов интерфейса Если че блин (initialization, инициирование — приведение цифрового устройства или его программы в состояние готовности к использованию)
            strings = new List<string>();// Создание нового списка строк
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)// Обрабатывает кнопку "Добавить"
        {
            string newString = textBoxInput.Text.Trim();// Получение текста из места куда мы его написали
            if (!string.IsNullOrEmpty(newString))// Проверка, не пустая ли строка
            {
                strings.Add(newString);// Добавление новой строки в список
                UpdateListBox();// Обновление отображения списка
                textBoxInput.Clear();// Очистка текстового поля
            }
            else
            {
                MessageBox.Show("Введите строку");// Сообщение об ошибке
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)// Обрабатывает кнопку "Удалить"

        {
            if (listBoxStrings.SelectedItem != null)// Проверка, выбран ли элемент
            {
                strings.Remove(listBoxStrings.SelectedItem.ToString());// Удаление выбранного элемента из списка
                UpdateListBox();// Обновление списка
            }
            else
            {
                MessageBox.Show("Выберите строку");// Сообщение об ошибке(еще одно)
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)// Обрабатывает кнопку "Изменить"
        {
            if (listBoxStrings.SelectedItem != null)// Проверка, выбран ли элемент для редактирования
            {
                string selectedString = listBoxStrings.SelectedItem.ToString();// Получение выбранной строки
                string editedString = textBoxInput.Text.Trim();// Получение текста для редактирования
                if (!string.IsNullOrEmpty(editedString))// Проверка, не пустая ли новая строка
                {
                    int index = strings.IndexOf(selectedString);// Поиск индекса выбранной строки
                    strings[index] = editedString;// Замена старой строки на новую
                    UpdateListBox();// Обновление списка
                    textBoxInput.Clear();// Очистка текстового поля
                }
                else
                {
                    MessageBox.Show("Введите не пустую строку для изменения");// Сообщение об ошибке(опять)
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для изменения и введите то как хотите поменять");// Угодайте что это? Да это опять СООБЩЕНИЕ ОБ ОШИБКЕ!
            }
        }

        private void UpdateListBox()// Метод для обновления содержимого списка на экране
        {
            listBoxStrings.Items.Clear();// Очистка текущих элементов списка
            foreach (var str in strings)// Перебор всех строк в списке
            {
                listBoxStrings.Items.Add(str);// Добавление каждой строки в ListBox
            }
        }
    }
}
