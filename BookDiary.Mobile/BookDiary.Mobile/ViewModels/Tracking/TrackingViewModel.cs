﻿using BookDiary.Mobile.Services;
using BookDiary.Model.Requests.ReadingActivities;
using BookDiary.Model.Requests.UserBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookDiary.Mobile.ViewModels.Tracking
{
    public class TrackingViewModel : BaseViewModel
    {
        private readonly ApiService _booksService = new ApiService("Books");
        private readonly ApiService _userBooksService = new ApiService("UserBooks");
        private readonly ApiService _readingActivitiesService = new ApiService("ReadingActivities");
        public Model.Models.UserBook UserBook { get; set; }
        public TrackingViewModel(Model.Models.UserBook userBook = null)
        {
            UserBook = userBook;
            InitCommand = new Command(async () => await Init());
            AddPagesCommand = new Command(async () => await AddPages());
            MarkAsCompletedCommand = new Command(async () => await MarkAsCompleted());
        }

        private string _dateAndCurrentDay = default;
        public string DateAndCurrentDay
        {
            get
            {
                var startedReadingOn = UserBook.StartedReadingOn.ToString("dddd MMMM yyyy");
                var day = (DateTime.Now - UserBook.StartedReadingOn).Days;
                _dateAndCurrentDay = $"{startedReadingOn} - (Current reading day: {day})";
                return _dateAndCurrentDay;
            }
            set { SetProperty(ref _dateAndCurrentDay, value); }
        }

        private int _pagesRead = default;
        public int PagesRead
        {
            get { return _pagesRead; }
            set { SetProperty(ref _pagesRead, value); }
        }

        private int _totalPagesRead = default;
        public int TotalPagesRead
        {
            get { return _totalPagesRead; }
            set { SetProperty(ref _totalPagesRead, value); }
        }

        private Model.Models.Book _book = null;
        public Model.Models.Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand AddPagesCommand { get; set; }
        public ICommand MarkAsCompletedCommand { get; set; }
        public async Task Init()
        {
            var bookEntity = await _booksService.GetById<Model.Models.Book>(UserBook.Id);
            Book = bookEntity;

            var searchRequest = new ReadingActivitiesSearchRequest()
            {
                IsUserBooksLoadingEnabled = true,
                UserBookId = UserBook.Id
            };

            var readingActivities = await _readingActivitiesService.Get<List<Model.Models.ReadingActivity>>(searchRequest);
            TotalPagesRead = readingActivities.Sum(activity => activity.PagesRead);
        }

        public async Task AddPages()
        {
            var request = new ReadingActivitiesUpsertRequest()
            {
                UserBookId = UserBook.Id,
                PagesRead = PagesRead
            };

            PagesRead = default;

            var entity = await _readingActivitiesService.Insert<Model.Models.ReadingActivity>(request);
        }

        public async Task MarkAsCompleted()
        {
            var request = new UserBooksUpsertRequest()
            {
                FinishedReadingOn = DateTime.Now,
                BookId = Book.Id,
                StartedReadingOn = UserBook.StartedReadingOn,
                UserId = UserBook.UserId
            };

            var entity = await _userBooksService.Update<Model.Models.UserBook>(UserBook.Id, request);

            if (entity != null)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully completed a book", "Thanks");
            }
        }
    }
}