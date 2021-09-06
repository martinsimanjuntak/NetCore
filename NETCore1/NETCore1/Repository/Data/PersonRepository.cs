﻿using Microsoft.EntityFrameworkCore;
using NETCore1.Context;
using NETCore1.Models;
using NETCore1.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NETCore1.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, string>
    {
        private readonly MyContext myContext;
        public PersonRepository (MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public IEnumerable<PersonViewModel> GetPerson(string nnik)
        {
            var GetPerson = (from p in myContext.Persons
                             where p.NIK == nnik
                             join a in myContext.Accounts
                             on p.NIK equals a.NIK
                             join pr in myContext.Profilings
                             on a.NIK equals pr.NIK
                             join e in myContext.Educations
                             on pr.Education_id equals e.Id
                             join u in myContext.Universities
                             on e.Univesity_id equals u.Id

                             select new PersonViewModel
                             {
                                 NIK = p.NIK,
                                 NamaDepan = p.Firstname + " " + p.Lastname,
                                 NamaBelakang = p.Lastname,
                                 Email = p.Email,
                                 Telp = p.Phone,
                                 TglLahir = p.BirthDate,
                                 Password = a.Password,
                                 Degree = e.Degree,
                                 GPA = e.GPA,
                                 Unversity_Id = u.Id,
                                 Education_id = e.Id
                             }).ToList();

            return GetPerson;

        }
        public IEnumerable<PersonViewModel> GetPerson()
        {
            var GetPerson = (from p in myContext.Persons
                             join a in myContext.Accounts
                             on p.NIK equals a.NIK
                             join pr in myContext.Profilings
                             on a.NIK equals pr.NIK
                             join e in myContext.Educations
                             on pr.Education_id equals e.Id
                             join u in myContext.Universities
                             on e.Univesity_id equals u.Id
                             select new PersonViewModel
                             {
                                 NIK = p.NIK,
                                 NamaDepan = p.Firstname + " " + p.Lastname,
                                 NamaBelakang = p.Lastname,
                                 Email = p.Email,
                                 Telp = p.Phone,
                                 TglLahir = p.BirthDate,
                                 Password = a.Password,
                                 Degree = e.Degree,
                                 GPA = e.GPA,
                                 Unversity_Id = u.Id,
                                 Education_id = e.Id
                                 
                                 
                             }).ToList();

            return GetPerson;

        }
        public bool Register(PersonViewModel personViewModel)
        {
           
            
            try
            {
                var phonecheck = myContext.Persons.Where(x => x.Phone.Equals(personViewModel.Telp)).Count();
                var emailcheck = myContext.Persons.Where(x => x.Email.Equals(personViewModel.Email)).Count();
                if (phonecheck == 0 && emailcheck == 0)
                {
                    var person = new Person()
                    {
                        NIK = personViewModel.NIK,
                        Firstname = personViewModel.NamaDepan,
                        Lastname = personViewModel.NamaBelakang,
                        Phone = personViewModel.Telp,
                        BirthDate = personViewModel.TglLahir,
                        Email = personViewModel.Email,

                    };
                    myContext.Persons.Add(person);
                    var insert = myContext.SaveChanges();
                    var account = new Account()
                    {
                        NIK = personViewModel.NIK,
                        Password = personViewModel.Password
                    };

                    myContext.Accounts.Add(account);
                    insert = myContext.SaveChanges();
                    var education = new Education()
                    {
                        Degree = personViewModel.Degree,
                        GPA = personViewModel.GPA,
                        Univesity_id = personViewModel.Unversity_Id
                    };

                    myContext.Educations.Add(education);
                    insert = myContext.SaveChanges();
                    var profiling = new Profiling
                    {
                        NIK = personViewModel.NIK,
                        Education_id = education.Id
                    };

                    myContext.Profilings.Add(profiling);
                    insert = myContext.SaveChanges();


                    return true;

                }
                else
                {
                    return false;
                    
                }
               
                   

            }
            catch
            {
                throw new DbUpdateException();
            }
        }


    }
}
