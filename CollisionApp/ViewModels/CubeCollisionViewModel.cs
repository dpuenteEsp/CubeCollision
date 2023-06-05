using CollisionApp.Utils;
using CollisionServices.Interfaces;
using CollisionServices.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CollisionApp.ViewModels
{
    public class CubeCollisionViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Members

        private readonly ICubeCollisionService collisionService;

        #endregion

        #region Properties

        private string cube1Dimensions;
        public string Cube1Dimensions
        {
            get { return cube1Dimensions; }
            set
            {
                cube1Dimensions = value;
                OnPropertyChanged(nameof(Cube1Dimensions));
                OnPropertyChanged(nameof(Error));
            }
        }

        private string cube2Dimensions;
        public string Cube2Dimensions
        {
            get { return cube2Dimensions; }
            set
            {
                cube2Dimensions = value;
                OnPropertyChanged(nameof(Cube2Dimensions));
                OnPropertyChanged(nameof(Error));
            }
        }

        private string cube1X;
        public string Cube1X
        {
            get { return cube1X; }
            set
            {
                cube1X = value;
                OnPropertyChanged(nameof(Cube1X));
                OnPropertyChanged(nameof(Error));
            }
        }

        private string cube1Y;
        public string Cube1Y
        {
            get { return cube1Y; }
            set
            {
                cube1Y = value;
                OnPropertyChanged(nameof(Cube1Y));
                OnPropertyChanged(nameof(Error));
            }
        }

        private string cube1Z;
        public string Cube1Z
        {
            get { return cube1Z; }
            set
            {
                cube1Z = value;
                OnPropertyChanged(nameof(Cube1Z));
                OnPropertyChanged(nameof(Error));
            }
        }

        private string cube2X;
        public string Cube2X
        {
            get { return cube2X; }
            set
            {
                cube2X = value;
                OnPropertyChanged(nameof(Cube2X));
                OnPropertyChanged(nameof(Error));
            }
        }

        private string cube2Y;
        public string Cube2Y
        {
            get { return cube2Y; }
            set
            {
                cube2Y = value;
                OnPropertyChanged(nameof(Cube2Y));
                OnPropertyChanged(nameof(Error));
            }
        }

        private string cube2Z;
        public string Cube2Z
        {
            get { return cube2Z; }
            set
            {
                cube2Z = value;
                OnPropertyChanged(nameof(Cube2Z));
                OnPropertyChanged(nameof(Error));
            }
        }

        private bool collisionResult;
        public bool CollisionResult 
        {
            get { return collisionResult; }
            set 
            {
                collisionResult = value;    
                OnPropertyChanged(nameof(CollisionResult));
                OnPropertyChanged(nameof(Error));
            }
        }

        private double intersectedVolume;
        public double IntersectedVolume
        {
            get { return intersectedVolume; }
            set
            {
                intersectedVolume = value;
                OnPropertyChanged(nameof(IntersectedVolume));
                OnPropertyChanged(nameof(Error));
            }
        }

        #endregion

        #region Commands

        public ICommand CheckCollisionCommand { get; }

        #endregion

        #region Constructor

        public CubeCollisionViewModel(ICubeCollisionService collisionService)
        {
            this.collisionService = collisionService;
            CheckCollisionCommand = new RelayCommand(CheckCollision);
        }

        #endregion

        #region Methods

        private bool IsValidDimension(string dimension)
        {
            return double.TryParse(dimension, out double result) && result > 0 && result <= 20;
        }

        private bool IsValidPosition(string position)
        {
            return double.TryParse(position, out double result) && result >= 0 && result <= 100;
        }

        private void CheckCollision()
        {
            if (!IsValidDimension(Cube1Dimensions) || !IsValidPosition(Cube1X) || !IsValidPosition(Cube1Y) || !IsValidPosition(Cube1Z)
                || !IsValidDimension(Cube2Dimensions) || !IsValidPosition(Cube2X) || !IsValidPosition(Cube2Y) || !IsValidPosition(Cube2Z))
            {
                MessageBox.Show("Check the fields!", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Cube cube1 = new Cube(double.Parse(Cube1Dimensions), double.Parse(Cube1X), double.Parse(Cube1Y), double.Parse(Cube1Z));
                Cube cube2 = new Cube(double.Parse(Cube2Dimensions), double.Parse(Cube2X), double.Parse(Cube2Y), double.Parse(Cube2Z));

                CollisionResult = collisionService.CheckCollision(cube1, cube2);
                IntersectedVolume = collisionService.CalculateIntersectedVolume(cube1, cube2);
            }            
        }

        #endregion

        #region IDataErrorInfo

        public bool NoErrors { get { return string.IsNullOrEmpty(Error); } }            

        public string Error => this[nameof(Cube1Dimensions)] ?? this[nameof(Cube1X)] ?? this[nameof(Cube1Y)] ??
                            this[nameof(Cube1Z)] ?? this[nameof(Cube2Dimensions)] ?? this[nameof(Cube2X)] ??
                            this[nameof(Cube2Y)] ?? this[nameof(Cube2Z)];

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case nameof(Cube1Dimensions):
                        if (!string.IsNullOrEmpty(Cube1Dimensions) && !IsValidDimension(Cube1Dimensions))
                            error = "Number less than or equal to 20.";
                        break;
                    case nameof(Cube1X):
                    case nameof(Cube1Y):
                    case nameof(Cube1Z):
                        if ((!string.IsNullOrEmpty(Cube1X) && !IsValidPosition(Cube1X)) ||
                            (!string.IsNullOrEmpty(Cube1Y) && !IsValidPosition(Cube1Y)) || 
                            (!string.IsNullOrEmpty(Cube1Z) && !IsValidPosition(Cube1Z)))
                            error = "Number between 0 and 100.";
                        break;
                    case nameof(Cube2Dimensions):
                        if (!string.IsNullOrEmpty(Cube1X) && !IsValidDimension(Cube2Dimensions))
                            error = "Number less than or equal to 20.";
                        break;
                    case nameof(Cube2X):
                    case nameof(Cube2Y):
                    case nameof(Cube2Z):
                        if ((!string.IsNullOrEmpty(Cube2X) && !IsValidPosition(Cube2X)) ||
                            (!string.IsNullOrEmpty(Cube2Y) && !IsValidPosition(Cube2Y)) ||
                            (!string.IsNullOrEmpty(Cube2Z) && !IsValidPosition(Cube2Z)))
                            error = "Number between 0 and 100.";
                        break;
                }

                return error;
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
