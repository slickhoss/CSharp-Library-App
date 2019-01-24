using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Common;

namespace CSharpLibraryApp
{
    class BookViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string sku;
        string title;
        string author;
        string genre;
        string publisher;
        string publishedYear;
        bool checkedOut;
        DateTime dateCheckedOut;
        DateTime dueDate;
        BookCollection books;
                 
        public BookCollection Books
        {
            get { return books; }
            set { books = value; }
        }
    }
}
