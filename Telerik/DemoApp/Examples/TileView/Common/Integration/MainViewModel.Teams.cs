﻿using System;

namespace Telerik.Windows.Examples.TileView.Common.ViewModels
{
	public partial class MainViewModel
	{
		private void AddTeams()
		{
			Team ferrariTeam = new Team();
			ferrariTeam.Name = "Scuderia Ferrari Marlboro";
			Pilot ferrariPilot = new Pilot();
			ferrariPilot.Name = "Fernando Alonso";
			ferrariPilot.Nationality = "Spain";
			ferrariPilot.Age = 29;
			ferrariPilot.FirstGrandPrix = 2001;
			ferrariPilot.Races = 157;
			ferrariPilot.Wins = 26;
			ferrariPilot.Championships = 2;
			ferrariPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", ferrariPilot.Name), UriKind.RelativeOrAbsolute);
			ferrariTeam.Pilot = ferrariPilot;
			Car ferrariCar = new Car();
			ferrariCar.Chassis = "F10";
			ferrariCar.Engine = "Ferrari 056";
			ferrariCar.Tyres = "Bridgestone Potenza";
			ferrariCar.FirstSeason = 1950;
			ferrariCar.WorldChampionships = 16;
			ferrariCar.HighestRaceFinish = "1 (x215)";
			ferrariCar.PolePositions = 205;
			ferrariCar.FastestLaps = 224;
			ferrariCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", ferrariTeam.Name), UriKind.RelativeOrAbsolute);
			ferrariTeam.Car = ferrariCar;
			this.Teams.Add(ferrariTeam);

			Team forceIndia = new Team();
			forceIndia.Name = "Force India F1 Team";
			Pilot forceIndiaPilot = new Pilot();
			forceIndiaPilot.Name = "Tonio Liuzzi";
			forceIndiaPilot.Nationality = "Italy";
			forceIndiaPilot.Age = 30;
			forceIndiaPilot.FirstGrandPrix = 2005;
			forceIndiaPilot.Races = 61;
			forceIndiaPilot.Wins = 0;
			forceIndiaPilot.Championships = 0;
			forceIndiaPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", forceIndiaPilot.Name), UriKind.RelativeOrAbsolute);
			forceIndia.Pilot = forceIndiaPilot;
			Car forceIndiaCar = new Car();
			forceIndiaCar.Chassis = "VJM03";
			forceIndiaCar.Engine = "Mercedes-Benz";
			forceIndiaCar.Tyres = "Bridgestone Potenza";
			forceIndiaCar.FirstSeason = 2008;
			forceIndiaCar.WorldChampionships = 0;
			forceIndiaCar.HighestRaceFinish = "2 (x1)";
			forceIndiaCar.PolePositions = 1;
			forceIndiaCar.FastestLaps = 1;
			forceIndiaCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", forceIndia.Name), UriKind.RelativeOrAbsolute);
			forceIndia.Car = forceIndiaCar;
			this.Teams.Add(forceIndia);

			Team hrtTeam = new Team();
			hrtTeam.Name = "HRT F1 Team";
			Pilot hrtPilot = new Pilot();
			hrtPilot.Name = "Karun Chandhok";
			hrtPilot.Nationality = "India";
			hrtPilot.Age = 26;
			hrtPilot.FirstGrandPrix = 2010;
			hrtPilot.Races = 10;
			hrtPilot.Wins = 0;
			hrtPilot.Championships = 0;
			hrtPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", hrtPilot.Name), UriKind.RelativeOrAbsolute);
			hrtTeam.Pilot = hrtPilot;
			Car hrtCar = new Car();
			hrtCar.Chassis = "F110";
			hrtCar.Engine = "Cosworth CA2010";
			hrtCar.Tyres = "Bridgestone Potenza";
			hrtCar.FirstSeason = 2010;
			hrtCar.WorldChampionships = 0;
			hrtCar.HighestRaceFinish = "14 (x3)";
			hrtCar.PolePositions = 0;
			hrtCar.FastestLaps = 0;
			hrtCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", hrtTeam.Name), UriKind.RelativeOrAbsolute);
			hrtTeam.Car = hrtCar;
			this.Teams.Add(hrtTeam);

			Team lotusTeam = new Team();
			lotusTeam.Name = "Lotus Racing";
			Pilot lotusPilot = new Pilot();
			lotusPilot.Name = "Heikki Kovalainen";
			lotusPilot.Nationality = "Finland";
			lotusPilot.Age = 29;
			lotusPilot.FirstGrandPrix = 2007;
			lotusPilot.Races = 69;
			lotusPilot.Wins = 1;
			lotusPilot.Championships = 0;
			lotusPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", lotusPilot.Name), UriKind.RelativeOrAbsolute);
			lotusTeam.Pilot = lotusPilot;
			Car lotusCar = new Car();
			lotusCar.Chassis = "T127";
			lotusCar.Engine = "Cosworth CA2010";
			lotusCar.Tyres = "Bridgestone Potenza";
			lotusCar.FirstSeason = 2010;
			lotusCar.WorldChampionships = 0;
			lotusCar.HighestRaceFinish = "12 (x1)";
			lotusCar.PolePositions = 0;
			lotusCar.FastestLaps = 0;
			lotusCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", lotusTeam.Name), UriKind.RelativeOrAbsolute);
			lotusTeam.Car = lotusCar;
			this.Teams.Add(lotusTeam);

			Team mcLarenTeam = new Team();
			mcLarenTeam.Name = "Vodafone McLaren Mercedes";
			Pilot mcLarenPilot = new Pilot();
			mcLarenPilot.Name = "Jenson Button";
			mcLarenPilot.Nationality = "Great Britain";
			mcLarenPilot.Age = 30;
			mcLarenPilot.FirstGrandPrix = 2000;
			mcLarenPilot.Races = 189;
			mcLarenPilot.Wins = 9;
			mcLarenPilot.Championships = 1;
			mcLarenPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", mcLarenPilot.Name), UriKind.RelativeOrAbsolute);
			mcLarenTeam.Pilot = mcLarenPilot;
			Car mcLarenCar = new Car();
			mcLarenCar.Chassis = "MP4-25";
			mcLarenCar.Engine = "Mercedes-Benz FO 108X";
			mcLarenCar.Tyres = "Bridgestone Potenza";
			mcLarenCar.FirstSeason = 1966;
			mcLarenCar.WorldChampionships = 8;
			mcLarenCar.HighestRaceFinish = "1 (x169)";
			mcLarenCar.PolePositions = 146;
			mcLarenCar.FastestLaps = 140;
			mcLarenCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", mcLarenTeam.Name), UriKind.RelativeOrAbsolute);
			mcLarenTeam.Car = mcLarenCar;
			this.Teams.Add(mcLarenTeam);

			Team mercedesTeam = new Team();
			mercedesTeam.Name = "Mercedes GP Petronas F1 Team";
			Pilot mercedesPilot = new Pilot();
			mercedesPilot.Name = "Nico Rosberg";
			mercedesPilot.Nationality = "Germany";
			mercedesPilot.Age = 25;
			mercedesPilot.FirstGrandPrix = 2006;
			mercedesPilot.Races = 87;
			mercedesPilot.Wins = 0;
			mercedesPilot.Championships = 0;
			mercedesPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", mercedesPilot.Name), UriKind.RelativeOrAbsolute);
			mercedesTeam.Pilot = mercedesPilot;
			Car mercedesCar = new Car();
			mercedesCar.Chassis = "MGP W01";
			mercedesCar.Engine = "Mercedes-Benz";
			mercedesCar.Tyres = "Bridgestone Potenza";
			mercedesCar.FirstSeason = 2010;
			mercedesCar.WorldChampionships = 0;
			mercedesCar.HighestRaceFinish = "3 (x3)";
			mercedesCar.PolePositions = 0;
			mercedesCar.FastestLaps = 0;
			mercedesCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", mercedesTeam.Name), UriKind.RelativeOrAbsolute);
			mercedesTeam.Car = mercedesCar;
			this.Teams.Add(mercedesTeam);

			Team redBullTeam = new Team();
			redBullTeam.Name = "Red Bull Racing";
			Pilot redBullPilot = new Pilot();
			redBullPilot.Name = "Sebastian Vettel";
			redBullPilot.Nationality = "Germany";
			redBullPilot.Age = 23;
			redBullPilot.FirstGrandPrix = 2007;
			redBullPilot.Races = 60;
			redBullPilot.Wins = 8;
			redBullPilot.Championships = 0;
			redBullPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", redBullPilot.Name), UriKind.RelativeOrAbsolute);
			redBullTeam.Pilot = redBullPilot;
			Car redBullCar = new Car();
			redBullCar.Chassis = "RB6";
			redBullCar.Engine = "Renault RS27-2010";
			redBullCar.Tyres = "Bridgestone Potenza";
			redBullCar.FirstSeason = 2005;
			redBullCar.WorldChampionships = 0;
			redBullCar.HighestRaceFinish = "1 (x13)";
			redBullCar.PolePositions = 19;
			redBullCar.FastestLaps = 12;
			redBullCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", redBullTeam.Name), UriKind.RelativeOrAbsolute);
			redBullTeam.Car = redBullCar;
			this.Teams.Add(redBullTeam);

			Team renaultTeam = new Team();
			renaultTeam.Name = "Renault F1 Team";
			Pilot renaultPilot = new Pilot();
			renaultPilot.Name = "Robert Kubica";
			renaultPilot.Nationality = "Poland";
			renaultPilot.Age = 25;
			renaultPilot.FirstGrandPrix = 2006;
			renaultPilot.Races = 74;
			renaultPilot.Wins = 1;
			renaultPilot.Championships = 0;
			renaultPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", renaultPilot.Name), UriKind.RelativeOrAbsolute);
			renaultTeam.Pilot = renaultPilot;
			Car renaultCar = new Car();
			renaultCar.Chassis = "R30";
			renaultCar.Engine = "Renault RS27-2010";
			renaultCar.Tyres = "Bridgestone Potenza";
			renaultCar.FirstSeason = 1977;
			renaultCar.WorldChampionships = 2;
			renaultCar.HighestRaceFinish = "1 (x35)";
			renaultCar.PolePositions = 51;
			renaultCar.FastestLaps = 31;
			renaultCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", renaultTeam.Name), UriKind.RelativeOrAbsolute);
			renaultTeam.Car = renaultCar;
			this.Teams.Add(renaultTeam);

			Team bmwTeam = new Team();
			bmwTeam.Name = "BMW Sauber F1 Team";
			Pilot bmwPilot = new Pilot();
			bmwPilot.Name = "Nick Heidfeld";
			bmwPilot.Nationality = "Germany";
			bmwPilot.Age = 33;
			bmwPilot.FirstGrandPrix = 2000;
			bmwPilot.Races = 173;
			bmwPilot.Wins = 0;
			bmwPilot.Championships = 0;
			bmwPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", bmwPilot.Name), UriKind.RelativeOrAbsolute);
			bmwTeam.Pilot = bmwPilot;
			Car bmwCar = new Car();
			bmwCar.Chassis = "C29";
			bmwCar.Engine = "Ferrari 056";
			bmwCar.Tyres = "Bridgestone Potenza";
			bmwCar.FirstSeason = 1993;
			bmwCar.WorldChampionships = 0;
			bmwCar.HighestRaceFinish = "1 (x1)";
			bmwCar.PolePositions = 1;
			bmwCar.FastestLaps = 2;
			bmwCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", bmwTeam.Name), UriKind.RelativeOrAbsolute);
			bmwTeam.Car = bmwCar;
			this.Teams.Add(bmwTeam);

			Team toroRossoTeam = new Team();
			toroRossoTeam.Name = "Scuderia Toro Rosso";
			Pilot toroRossoPilot = new Pilot();
			toroRossoPilot.Name = "Jaime Alguersuari";
			toroRossoPilot.Nationality = "Spain";
			toroRossoPilot.Age = 20;
			toroRossoPilot.FirstGrandPrix = 2009;
			toroRossoPilot.Races = 25;
			toroRossoPilot.Wins = 0;
			toroRossoPilot.Championships = 0;
			toroRossoPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", toroRossoPilot.Name), UriKind.RelativeOrAbsolute);
			toroRossoTeam.Pilot = toroRossoPilot;
			Car toroRossoCar = new Car();
			toroRossoCar.Chassis = "STR5";
			toroRossoCar.Engine = "Ferrari 056";
			toroRossoCar.Tyres = "Bridgestone Potenza";
			toroRossoCar.FirstSeason = 2006;
			toroRossoCar.WorldChampionships = 0;
			toroRossoCar.HighestRaceFinish = "1 (x1)";
			toroRossoCar.PolePositions = 1;
			toroRossoCar.FastestLaps = 0;
			toroRossoCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", toroRossoTeam.Name), UriKind.RelativeOrAbsolute);
			toroRossoTeam.Car = toroRossoCar;
			this.Teams.Add(toroRossoTeam);

			Team virginTeam = new Team();
			virginTeam.Name = "Virgin Racing";
			Pilot virginPilot = new Pilot();
			virginPilot.Name = "Lucas di Grassi";
			virginPilot.Nationality = "Brazil";
			virginPilot.Age = 26;
			virginPilot.FirstGrandPrix = 2010;
			virginPilot.Races = 17;
			virginPilot.Wins = 0;
			virginPilot.Championships = 0;
			virginPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", virginPilot.Name), UriKind.RelativeOrAbsolute);
			virginTeam.Pilot = virginPilot;
			Car virginCar = new Car();
			virginCar.Chassis = "VR-01";
			virginCar.Engine = "Cosworth CA2010";
			virginCar.Tyres = "Bridgestone Potenza";
			virginCar.FirstSeason = 2010;
			virginCar.WorldChampionships = 0;
			virginCar.HighestRaceFinish = "14 (x2)";
			virginCar.PolePositions = 0;
			virginCar.FastestLaps = 0;
			virginCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", virginTeam.Name), UriKind.RelativeOrAbsolute);
			virginTeam.Car = virginCar;
			this.Teams.Add(virginTeam);

			Team williamsTeam = new Team();
			williamsTeam.Name = "Williams";
			Pilot williamsPilot = new Pilot();
			williamsPilot.Name = "Rubens Barrichello";
			williamsPilot.Nationality = "Brazil";
			williamsPilot.Age = 38;
			williamsPilot.FirstGrandPrix = 1993;
			williamsPilot.Races = 305;
			williamsPilot.Wins = 11;
			williamsPilot.Championships = 0;
			williamsPilot.ProfilePicture = new Uri(string.Format("../../Images/TileView/Integration/PilotProfilePics/{0}.jpg", williamsPilot.Name), UriKind.RelativeOrAbsolute);
			williamsTeam.Pilot = williamsPilot;
			Car williamsCar = new Car();
			williamsCar.Chassis = "FW32";
			williamsCar.Engine = "Cosworth CA2010";
			williamsCar.Tyres = "Bridgestone Potenza";
			williamsCar.FirstSeason = 1975;
			williamsCar.WorldChampionships = 9;
			williamsCar.HighestRaceFinish = "1 (x113)";
			williamsCar.PolePositions = 125;
			williamsCar.FastestLaps = 130;
			williamsCar.CarPicture = new Uri(string.Format("../../Images/TileView/Integration/CarPics/{0}.jpg", williamsTeam.Name), UriKind.RelativeOrAbsolute);
			williamsTeam.Car = williamsCar;
			this.Teams.Add(williamsTeam);
		}
	}
}
