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
    public class TC01 : TestBase
    {
        [Test]
        public void TC01_Verify_Add_People_Successfully()
        {
            int genNum = _random.Next();
            _employees = new List<PeopleEntity>()
            {
                new PeopleEntity(){FirstName = "Joely" + genNum, LastName = "Simons", Email = "Joely.Simons"+ genNum + "@gmail.com", StartDate = DateTime.Today, Manager = username, PositionTile = ""},
                new PeopleEntity(){FirstName = "Lenny" + genNum, LastName = "Mccormack", Email = "Lenny.Mccormack"+ genNum + "@gmail.com", StartDate = DateTime.Today, Manager = username, PositionTile = ""}
            };

            LoginToTINYpulse();

            GoToAddPeople();

            Add_Some_People_Into_List(_employees);

            Verify_Congratulations_page_displays(_employees);
        }


        private List<PeopleEntity> _employees;
        private readonly Random _random = new Random();

        private void Add_Some_People_Into_List(List<PeopleEntity> employees)
        {
            _addPeople = new AddPeoplePage();
            for (int i = 0; i < employees.Count; i++)
            {
                _addPeople.AddPeopleToList(i, employees[i].FirstName,
                                    employees[i].LastName,
                                    employees[i].Email,
                                    employees[i].StartDate,
                                    username,
                                    employees[i].PositionTile);
            }

            _addPeople.SubmitAddPeople();
        }

        public void Verify_Congratulations_page_displays(List<PeopleEntity> employees)
        {


            _congratulationsPage = new CongratulationsPage();
            _congratulationsPage.Check_Finish_Page_Loaded(employees);

            for (int i = 0; i < employees.Count; i++)
            {
                _congratulationsPage.Check_People_is_added(i, employees[i]);
            }
        }
    }
}
