// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using Sitecore.MobileSDK.API.Items;
using UIKit;
using UTStoreDemo.Helpers;
using UTStoreDemo.UI;

namespace UTStoreDemo
{
	public partial class CountriesViewController : UITableViewController
	{
        DataSource dataSource;
        public ISitecoreItem CurrentRegion = null;

        protected CountriesViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = NSBundle.MainBundle.GetLocalizedString("Countries");
        }

        public override void ViewWillAppear(bool animated)
        {
            ClearsSelectionOnViewWillAppear = SplitViewController.Collapsed;
            base.ViewWillAppear(animated);

            this.GetCountriesForRegion(this.CurrentRegion);
        }

        public async void GetCountriesForRegion(ISitecoreItem region)
        {
            if (dataSource == null)
            {
                ScItemsResponse response = await NetworkHelper.GetCountriesForRegion(region);
                TableView.Source = dataSource = new DataSource(this, response);
            }

            TableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }



        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showCities")
            {
                var controller = (CitiesViewController)segue.DestinationViewController;
                var indexPath = TableView.IndexPathForSelectedRow;
                var item = dataSource.Objects[indexPath.Row];

                controller.CurrentCountry = item;
                controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
                controller.NavigationItem.LeftItemsSupplementBackButton = true;
            }
        }

        class DataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("CoutnryNavigationCell");
            readonly ScItemsResponse objects;
            readonly CountriesViewController controller;
            private HttpClient httpClient = new HttpClient();

            public DataSource(CountriesViewController controller, ScItemsResponse data)
            {
                this.controller = controller;
                this.objects = data;
            }

            public ScItemsResponse Objects
            {
                get { return objects; }
            }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return objects.ResultCount;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                CountryNavigationCell cell = (CountryNavigationCell)tableView.DequeueReusableCell(CellIdentifier, indexPath);

                cell.SetItem(objects[indexPath.Row], this.httpClient);

                return cell;
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
            {
                // Return false if you do not want the specified item to be editable.
                return false;
            }


        }
    }
}
