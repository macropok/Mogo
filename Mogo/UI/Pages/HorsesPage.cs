using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Mogo
{
	public class HorsesPage : ContentPage
	{
		public class CustomCell:ViewCell
		{
			public Label HorseName;
			public Label HipNumber;
			public Label YearFold;
			public Image HorsePhoto;
			public CustomCell()
			{


					HorseName = new Label{ 
						Text = "",
						TextColor = Color.White,
					};
					HorseName.SetBinding (Label.TextProperty, "HorseName");

					HipNumber = new Label {
						Text = "",
						TextColor = Color.White,
					};
					HipNumber.SetBinding (Label.TextProperty, "HipNumber");

					YearFold = new Label{ 
						Text = "",
						TextColor = Color.Yellow,
					};
					YearFold.SetBinding (Label.TextProperty, "YearFold");

					HorsePhoto = new Image{
						Source = ImageSource.FromResource("Mogo.images.horse.png"),
						HeightRequest = 100, WidthRequest = 100,
					};
					HorsePhoto.SetBinding (Image.SourceProperty, "HorsePhoto");

					View = new StackLayout {
						Orientation = StackOrientation.Horizontal, 
						Children = {
							HorsePhoto,
							new StackLayout{
								Orientation = StackOrientation.Vertical,
								Children = {
									HorseName,
									HipNumber,
									YearFold,
								}
							}
						}		
					};

				}
		}

		public class Horses {
			public string HorsePhoto {get;set;} //will be a string passed with the local path
			public string HorseName {get;set;}
			public string HipNumber {get;set;}
			public string YearFold {get;set;}
			public string Sire {get;set;}
			public string Dam {get;set;}
			public string ID { get; set;}
		}

		public TableView tableView;
		TableSection mainSection;
		public List<Horses> _horseList;
		public List<CustomCell> _cellList;
		public String horseID;
		//CustomCell cell;


		public HorsesPage ()
		{
			this.Title="Main Menu";
			NavigationPage.SetBackButtonTitle (this, "Horses");
			_horseList = new List<Horses> ();

			mainSection = new TableSection ();

			Horses horse = new Horses();
			horse.HorseName = "Test Name 1";
			horse.HipNumber = "Hip Number 1";
			horse.YearFold = "2014 Sorrel Mare";
			horse.ID = "aaa";

			_horseList.Add (horse);

			Horses horse1 = new Horses();
			horse1.HorseName = "Test Name 2";
			horse1.HipNumber = "Hip Number 2";
			horse1.YearFold = "2014 Sorrel Mare";
			horse1.ID = "bbb";
			_horseList.Add (horse1);

			Horses horse2 = new Horses();
			horse2.HorseName = "Test Name 3";
			horse2.HipNumber = "Hip Number 3";
			horse2.YearFold = "2014 Sorrel Mare";
			horse2.ID = "ccc";
			_horseList.Add (horse2);

			Horses horse3 = new Horses();
			horse3.HorseName = "Test Name 4";
			horse3.HipNumber = "Hip Number 4";
			horse3.YearFold = "2014 Sorrel Mare";
			horse3.ID = "ddd";
			_horseList.Add (horse3);

			Horses horse4 = new Horses();
			horse4.HorseName = "Test Name 5";
			horse4.HipNumber = "Hip Number 5";
			horse4.YearFold = "2014 Sorrel Mare";
			horse4.ID = "eee";
			_horseList.Add (horse4);

			Horses horse5 = new Horses();
			horse5.HorseName = "Test Name 6";
			horse5.HipNumber = "Hip Number 6";
			horse5.YearFold = "2014 Sorrel Mare";
			horse5.ID = "fff";
			_horseList.Add (horse5);

			Horses horse6 = new Horses();
			horse6.HorseName = "Test Name 7";
			horse6.HipNumber = "Hip Number 7";
			horse6.YearFold = "2014 Sorrel Mare";
			horse6.ID = "ggg";
			_horseList.Add (horse6);

			Horses horse7 = new Horses();
			horse7.HorseName = "Test Name 8";
			horse7.HipNumber = "Hip Number 8";
			horse7.YearFold = "2014 Sorrel Mare";
			horse7.ID = "hhh";
			_horseList.Add (horse7);


			_cellList = new List<CustomCell> ();



			for (int i = 0; i < _horseList.Count; i++) {

				CustomCell h = new CustomCell();
				h.HorseName.Text = _horseList[i].HorseName;
				h.HipNumber.Text = _horseList[i].HipNumber;
				h.HorsePhoto.Source= ImageSource.FromResource("Mogo.images.horse.png");
				h.YearFold.Text = _horseList[i].YearFold;

				_cellList.Add (h);

			}

			foreach (CustomCell h in _cellList) {
				mainSection.Add (h);
				h.Tapped += H_Tapped;
			}



			tableView = new TableView (){RowHeight = 100, BackgroundColor = Color.Black};

			tableView.Intent = TableIntent.Menu;

			tableView.Root = new TableRoot{
				mainSection
			};


			Content = tableView;
		}

		void H_Tapped (object sender, EventArgs e)
		{
			
			String strName = ((CustomCell)sender).HorseName.Text;
			String strHipNumber = ((CustomCell)sender).HipNumber.Text;
			foreach (Horses h in _horseList) {
				if (h.HorseName == strName && h.HipNumber == strHipNumber) {
					horseID = h.ID;
					break;
				}
			}

			if(horseID != null)
				Navigation.PushAsync (new HorseView (horseID){ });
		}


	}


}


