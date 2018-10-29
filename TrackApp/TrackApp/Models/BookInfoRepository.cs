using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TrackApp.ViewModels;

namespace TrackApp.Models
{
    public class BookInfoRepository
    {
        private ObservableCollection<BookInfo> bookInfo;

        public ObservableCollection<BookInfo> BookInfo
        {
            get { return bookInfo; }
            set { this.bookInfo = value; }
        }

        public BookInfoRepository()
        {
            GenerateBookInfo();
        }

        internal void GenerateBookInfo()
        {
            bookInfo = new ObservableCollection<BookInfo>();
            bookInfo.Add(new BookInfo() { BookName = "Runner 1", BookDescription = "Object-oriented programming is a programming paradigm based on the concept of objects" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 2", BookDescription = "Code Contracts provide a way to convey code assumptions" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 3", BookDescription = "You’ll learn several different approaches to applying machine learning" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 4", BookDescription = "Neural networks are an exciting field of software development" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 5", BookDescription = "It is a powerful tool for editing code and serves for end-to-end programming" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 6", BookDescription = "It is provides a useful overview of the Android application life cycle" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 7", BookDescription = "It is for developers looking to step into frightening world of iPhone" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 8", BookDescription = "The new version of the widely-used integrated development environment" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 9", BookDescription = "Its creates mappings from its C# classes and controls directly" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 10", BookDescription = "Windows Store apps present a radical shift in Windows development" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 11", BookDescription = "Object-oriented programming is a programming paradigm based on the concept of objects" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 12", BookDescription = "Code Contracts provide a way to convey code assumptions" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 13", BookDescription = "You’ll learn several different approaches to applying machine learning" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 14", BookDescription = "Neural networks are an exciting field of software development" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 15", BookDescription = "It is a powerful tool for editing code and serves for end-to-end programming" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 16", BookDescription = "It is provides a useful overview of the Android application life cycle" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 17", BookDescription = "It is for developers looking to step into frightening world of iPhone" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 18", BookDescription = "The new version of the widely-used integrated development environment" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 19", BookDescription = "Its creates mappings from its C# classes and controls directly" });
            bookInfo.Add(new BookInfo() { BookName = "Runner 20", BookDescription = "Windows Store apps present a radical shift in Windows development" });
        }
    }
}
