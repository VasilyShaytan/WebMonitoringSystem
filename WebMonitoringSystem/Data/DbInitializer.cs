using WebMonitoringSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebMonitoringSystem.Data
{
    public class DbInitializer
    {
        public static void Initialize(MonitoringSystemContext context)
        {
            if (!context.Database.EnsureCreated())
            {
                context.Database.Migrate();
            }

            // Look for any BasicParameters.
            if (context.BasicParameters.Any())
            {
                return;   // DB has been seeded
            }

            var basicParameters = new BasicParameter[]
            {
                new BasicParameter{SPNNameRu = "Время включения системы подачи газа", DataSource = "Отсутствует в J1339! (но есть Engine Total Hours of Gaseous Fuel Operation"},
                new BasicParameter{Acronym = "GFC", SPNName = "Trip Gaseous",SPNNameRu = "Расход газа", DataSource = "CAN-шина, при наличии расходомера газа. Иначе-вычисляется через давление и проходное сечение форсунки впрыска газа"},
                new BasicParameter{Acronym = "GP", SPNName = "Gas Pressure",SPNNameRu = "Давление газа", DataSource = "Внешний датчик давления"},
                new BasicParameter{Acronym = "GFC", SPNName = "Trip Fuel",SPNNameRu = "Расход дизельного топлива", DataSource = "CAN шина, или датчик расхода"},
                new BasicParameter{Acronym = "VD", SPNName = "Total Vehicle Distance",SPNNameRu = "Пробег автомобиля (пройденный путь)", DataSource = "CAN -шина"},
                new BasicParameter{Acronym = "WBVS", SPNName = "Wheel-Based Vehicle Speed",SPNNameRu = "Скорость движения", DataSource = "CAN -шина"},
                new BasicParameter{Acronym = "EEC1", SPNName = "Engine Speed",SPNNameRu = "Обороты двигателя", DataSource = "CAN -шина"},
                new BasicParameter{Acronym = "ECT", SPNName = "Engine Coolant Temperature",SPNNameRu = "Температура двигателя", DataSource = "CAN -шина"},
                new BasicParameter{Acronym = "TE", SPNName = "Exhaust Temperature",SPNNameRu = "Температура выхлопных газов", DataSource = "Дополнительный датчик на выхлопной  трубе"},

            };
            foreach (BasicParameter bp in basicParameters)
            {
                context.BasicParameters.Add(bp);
            }
            context.SaveChanges();



            /*if (context.Vehicles.Any())
            {
                return;   // DB has been seeded
            }*/


            var vehicles = new Vehicle[]
            {
                new Vehicle{Mark = "BMW", ModelType = "E540", СarryingСapacity = 2000, YearIssue = 1998, UsefulVolume = 430, VehicleType = "ГР", OverallDimensions = "20x30x40"},
                new Vehicle{Mark = "Mersedes", ModelType = "S230", СarryingСapacity = 4000, YearIssue = 1996, UsefulVolume = 930, VehicleType = "ГР", OverallDimensions = "50x70x60"},

            };
            foreach (Vehicle vh in vehicles)
            {
                context.Vehicles.Add(vh);
            }
            context.SaveChanges();

            // Table
            var vehiclegroups = new VehicleGroup[]
            {
                new VehicleGroup{VehicleGroupName = "TestVehicleGroup1"},
                new VehicleGroup{VehicleGroupName = "TestVehicleGroup2"},
                new VehicleGroup{VehicleGroupName = "TestVehicleGroup3"},

            };
            foreach (VehicleGroup vhg in vehiclegroups)
            {
                context.VehicleGroups.Add(vhg);
            }
            context.SaveChanges();

            // Table
            var vehicletovehiclegroups = new VehicleToVehicleGroup[]
            {
                new VehicleToVehicleGroup{VehicleGroupID = 2, VehicleID = 1},
                new VehicleToVehicleGroup{VehicleGroupID = 2, VehicleID = 2},
                new VehicleToVehicleGroup{VehicleGroupID = 3, VehicleID = 1},

            };
            foreach (VehicleToVehicleGroup vvg in vehicletovehiclegroups)
            {
                context.VehicleToVehicleGroups.Add(vvg);
            }
            context.SaveChanges();


            // Table
            var parameters = new Parameter[]
            {
                new Parameter{VehicleID = 1, BasicParameterID = 2, BasicParameterValue = 112, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 54)},
                new Parameter{VehicleID = 1, BasicParameterID = 3, BasicParameterValue = 113, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 54)},
                new Parameter{VehicleID = 1, BasicParameterID = 4, BasicParameterValue = 114, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 54)},
                new Parameter{VehicleID = 1, BasicParameterID = 5, BasicParameterValue = 115, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 54)},
                new Parameter{VehicleID = 1, BasicParameterID = 6, BasicParameterValue = 116, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 54)},
                new Parameter{VehicleID = 1, BasicParameterID = 7, BasicParameterValue = 117, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 54)},
                new Parameter{VehicleID = 1, BasicParameterID = 8, BasicParameterValue = 118, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 54)},
                new Parameter{VehicleID = 1, BasicParameterID = 9, BasicParameterValue = 119, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 54)},

                new Parameter{VehicleID = 1, BasicParameterID = 2, BasicParameterValue = 122, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 56)},
                new Parameter{VehicleID = 1, BasicParameterID = 3, BasicParameterValue = 123, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 56)},
                new Parameter{VehicleID = 1, BasicParameterID = 4, BasicParameterValue = 124, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 56)},
                new Parameter{VehicleID = 1, BasicParameterID = 5, BasicParameterValue = 125, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 56)},
                new Parameter{VehicleID = 1, BasicParameterID = 6, BasicParameterValue = 126, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 56)},
                new Parameter{VehicleID = 1, BasicParameterID = 7, BasicParameterValue = 127, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 56)},
                new Parameter{VehicleID = 1, BasicParameterID = 8, BasicParameterValue = 128, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 56)},
                new Parameter{VehicleID = 1, BasicParameterID = 9, BasicParameterValue = 129, BasicParameterTimeValue = new DateTime(2004, 10, 19, 10, 23, 56)},
            };
            foreach (Parameter p in parameters)
            {
                context.Parameters.Add(p);
            }
            context.SaveChanges();


            // Table
            var routes = new Route[]
            {
                new Route{VehicleID = 1, CoordinateLatitude = 60.001, CoordinateLongitude = 30.001},
                new Route{VehicleID = 1, CoordinateLatitude = 60.002, CoordinateLongitude = 30.002},
                new Route{VehicleID = 1, CoordinateLatitude = 60.003, CoordinateLongitude = 30.003},
                new Route{VehicleID = 1, CoordinateLatitude = 60.004, CoordinateLongitude = 30.004},
                new Route{VehicleID = 1, CoordinateLatitude = 60.005, CoordinateLongitude = 30.005},
                new Route{VehicleID = 2, CoordinateLatitude = 60.101, CoordinateLongitude = 30.101},

            };
            foreach (Route r in routes)
            {
                context.Routes.Add(r);
            }
            context.SaveChanges();


            // Table
            var users = new User[]
            {
                new User{UserLogin = "Vasiliy", UserPassword = "11112222", UserName = "Василий", UserSurname = "Шайтан", UserPhone = "7911", UserRole = 1},
                new User{UserLogin = "Sasha", UserPassword = "22221111", UserName = "Саша", UserSurname = "Иванов", UserPhone = "7921", UserRole = 2},

            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();


            // Table
            var roles = new Role[]
            {
                new Role{RoleName = "ADMIN"},
                new Role{RoleName = "USER"},

            };
            foreach (Role r in roles)
            {
                context.Roles.Add(r);
            }
            context.SaveChanges();


            // Table
            var usertoroles = new UserToRole[]
            {
                new UserToRole{UserID = 1, RoleID = 1},
                new UserToRole{UserID = 2, RoleID = 2},

            };
            foreach (UserToRole ur in usertoroles)
            {
                context.UserToRoles.Add(ur);
            }
            context.SaveChanges();

        }



    }
}
