using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using System;

namespace Xamrin_Sliding_Puzzle
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button resetButton;
        GridLayout mainLayout;
        int gameViewWidth;
        int tileWidth; 
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            setGameView();
            makeTilesMethod();
        }

        private void makeTilesMethod()
        {
            tileWidth = gameViewWidth / 4;
            TextView textTile = new TextView(this);
            GridLayout.Spec rowSpac = GridLayout.InvokeSpec(0);
            GridLayout.Spec colSpac = GridLayout.InvokeSpec(0);

            GridLayout.LayoutParams tileLayoutParams = new GridLayout.LayoutParams(rowSpac, colSpac);

            tileLayoutParams.Width = tileWidth;
            tileLayoutParams.Height = tileWidth;

            textTile.LayoutParameters = tileLayoutParams;
            textTile.SetBackgroundColor(Color.Green);

            mainLayout.AddView(textTile);

        }

        private void setGameView()
        {
            resetButton = FindViewById<Button>(Resource.Id.resetButton);
            resetButton.Click += ResetMethod;

            mainLayout = FindViewById<GridLayout>(Resource.Id.gameGridLayoutID);
            gameViewWidth = Resources.DisplayMetrics.WidthPixels;

            mainLayout.ColumnCount = 4;
            mainLayout.RowCount = 4;

            mainLayout.LayoutParameters = new LinearLayout.LayoutParams(gameViewWidth, gameViewWidth);
            mainLayout.SetBackgroundColor(Color.Gray);
        }

        private void ResetMethod(object sender, System.EventArgs e)
        {

        }
    }
}