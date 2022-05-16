using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using TINYpulse.Pages;
using TINYpulse.Entity;
using System.Collections.Generic;

namespace TINYpulse.TestCases
{
    public class TC02 : TestBase
    {
        [Test]
        public void TC02_Verify_Cannot_Add_Duplicate_People()
        {
            int genNum = _random.Next();
            _employees = new List<PeopleEntity>()
                {
                    new PeopleEntity(){FirstName = "Joely" + genNum, LastName = "Simons", Email = "Joely.Simons"+ genNum + "@gamil.com", StartDate = DateTime.Today, Manager = username, PositionTile = ""},
                };

            LoginToTINYpulse();

            GoToAddPeople();


            Add_People_Into_List(_employees);

            Verify_Error_Message_Displays_in_Congratulations_page_displays();
        }

        private List<PeopleEntity> _employees;
        private readonly Random _random = new Random();

        private void Add_People_Into_List(List<PeopleEntity> employees)
        {
            _addPeople = new AddPeoplePage();
            _addPeople.AddPeopleToList(0, employees[0].FirstName,
                                    employees[0].LastName,
                                    employees[0].Email,
                                    employees[0].StartDate,
                                    username,
                                    employees[0].PositionTile);

            _addPeople.SubmitAddPeople();

            _dashboard = new DashboardPage();
            _dashboard.ClickAddPeople();

            _addPeople.AddPeopleToList(0, employees[0].FirstName,
                                    employees[0].LastName,
                                    employees[0].Email,
                                    employees[0].StartDate,
                                    username,
                                    employees[0].PositionTile);

            _addPeople.SubmitAddPeople();
        }

        public void Verify_Error_Message_Displays_in_Congratulations_page_displays()
        {
            _congratulationsPage = new CongratulationsPage();
            _congratulationsPage.Check_Error_Message_Displays();
        }
    }
}
