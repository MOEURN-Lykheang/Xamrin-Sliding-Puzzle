using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections;

namespace Xamrin_Sliding_Puzzle
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button resetButton;
        GridLayout mainLayout;

        int gameViewWidth;
        int tileWidth;

        ArrayList tilesArr;
        ArrayList coordArr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            SetGameView();
            MakeTilesMethod();
            RandomizeMethod();
        }

        private void RandomizeMethod()
        {
            ArrayList tempCoords = new ArrayList(coordArr);

           Random myRand = new Random();
           foreach(TextView any in tilesArr)
            {
                int randIdx = myRand.Next(0,tempCoords.Count);
                Point thisRandLoc = (Point)tempCoords[randIdx];

                GridLayout.Spec rowSpec = GridLayout.InvokeSpec(thisRandLoc.Y);
                GridLayout.Spec colSpec = GridLayout.InvokeSpec(thisRandLoc.X);
                
                GridLayout.LayoutParams randLayoutParams = new GridLayout.LayoutParams(rowSpec, colSpec);

                randLayoutParams.Width = tileWidth - 10;
                randLayoutParams.Height = tileWidth - 10;
                randLayoutParams.SetMargins(5,5,5,5);

                any.LayoutParameters = randLayoutParams;
                tempCoords.RemoveAt(randIdx);
            }
        }

        private void MakeTilesMethod()
        {
            tilesArr = new ArrayList();
            coordArr = new ArrayList();
            int counter = 1;
            for (var h = 0; h < 4; h++) { 
                for(var v = 0; v < 4; v++) { 
                    tileWidth = gameViewWidth / 4;
                    TextView textTile = new TextView(this);
                    GridLayout.Spec rowSpec = GridLayout.InvokeSpec(h);
                    GridLayout.Spec colSpec = GridLayout.InvokeSpec(v);

                    GridLayout.LayoutParams tileLayoutParams = new GridLayout.LayoutParams(rowSpec, colSpec);

                    textTile.Text = counter.ToString();
                    textTile.SetBackgroundColor(Color.Black);
                    textTile.TextSize = 40;
                    textTile.Gravity = GravityFlags.Center;

                    tileLayoutParams.Width = tileWidth - 10 ;
                    tileLayoutParams.Height = tileWidth - 10;
                    tileLayoutParams.SetMargins(5, 5, 5, 5);


                    textTile.LayoutParameters = tileLayoutParams;
                    textTile.SetBackgroundColor(Color.Green);

                    Point thisLoc = new Point(v, h);
                    coordArr.Add(thisLoc);
                    tilesArr.Add(textTile);

                    mainLayout.AddView(textTile);
                    counter++;
                }
            }
            mainLayout.RemoveView((TextView)tilesArr[15]);
            tilesArr.RemoveAt(15);
        }

        private void SetGameView()
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
           RandomizeMethod();
        }
    }
}