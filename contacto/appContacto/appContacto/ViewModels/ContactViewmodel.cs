﻿namespace appContacto.ViewModels
{
    using appContacto.Models;
    using appContacto.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Xamarin.Forms;

    class ContactViewmodel : BaseViewModel
    {
        #region Attributes
        ApiService apiService;
        private ObservableCollection<Contact> contacts;
        #endregion

        #region Properties
        public ObservableCollection<Contact> Contacts
        {
            get { return this.contacts; }
            set { SetValue(ref this.contacts, value); }
        }
        #endregion

        #region Constructor
        public ContactViewmodel()
        {
            this.apiService = new ApiService();
            this.LoadContacts();
        }
        #endregion

        #region Methods
        private async void LoadContacts()
        {
            var connection = await this.apiService.CheckConnection();
            if(connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Connection Error",
                    connection.Message,
                    "Accept");
                return;
            }
            var response = await this.apiService.GetList<Contact>(
                "https://apicontactsi220.azurewebsites.net/",
                "api/",
                "Contacts");
            if(!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "GET Contact Error",
                    response.Message,
                    "Accept"
                    );
                return;

            }
            MainViewmodel mainViewmodel = MainViewmodel.GetInstance();
            mainViewmodel.ContactList = (List<Contact>) response.Result;

            this.Contacts = new ObservableCollection<Contact>(this.ToContactView());
        }

        private IEnumerable<Contact> ToContactView()
        {
            ObservableCollection<Contact> collection = new ObservableCollection<Contact>();
            MainViewmodel main = MainViewmodel.GetInstance();
            foreach(var lista in main.ContactList)
            {
                Contact contacto = new Contact();
                contacto.ContactID = lista.ContactID;
                contacto.Name = lista.Name;
                contacto.Type = lista.Type;
                contacto.ContactValue = lista.ContactValue;
                collection.Add(contacto);
            }
            return collection;   
        }
        #endregion
    }
}