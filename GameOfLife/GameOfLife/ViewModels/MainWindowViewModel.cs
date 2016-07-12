using GameOfLife.Utils;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GameOfLife.ViewModels
{
	public class MainWindowViewModel
	{
		private const string blackColorHexValue = "#FF000000";

		public MainWindowViewModel()
		{

		}

		private ICommand buttonClickCommand;
		public ICommand ButtonClickCommand
		{
			get
			{
				if (buttonClickCommand == null)
				{
					buttonClickCommand = new RelayCommand<object>(x =>
					{
						this.MakeButtonBackgroundBlack(x);
					});
				}
				return buttonClickCommand;
			}
		}

		private void MakeButtonBackgroundBlack(object x)
		{
			var button = x as Button;
			button.Background = new SolidColorBrush(Colors.Black);
		}

		private ICommand runGameCommand;
		public ICommand RunGameCommand
		{
			get
			{
				if (runGameCommand == null)
				{
					runGameCommand = new RelayCommand<object>(x =>
					{
						this.RemoveBadCells(x);
					});
				}
				return runGameCommand;
			}
		}

		private void RemoveBadCells(object x)
		{
			var grid = x as Grid;
			var selectedCells = new List<Button>();

			foreach (var child in grid.Children)
			{
				var button = child as Button;
				if (button.Background.ToString().Equals(blackColorHexValue))
					selectedCells.Add(button);
			}

			var evolvedCells = EvolveCells(selectedCells);
			RemoveDeadCells(evolvedCells, grid);
		}

		private void RemoveDeadCells(List<int> evolvedCells, Grid grid)
		{
			ClearAllSelectedItems(grid);
			RepaintLiveCells(evolvedCells, grid);
		}

		private void RepaintLiveCells(List<int> evolvedCells, Grid grid)
		{
			foreach (var child in grid.Children)
			{
				var button = child as Button;
				var cellNumnber = ConvertGridCoordinatesIntoCellNumber(Grid.GetRow(button), Grid.GetColumn(button));

				if (evolvedCells.Contains(cellNumnber))
					button.Background = new SolidColorBrush(Colors.Black);
			}
		}

		private void ClearAllSelectedItems(Grid grid)
		{
			foreach (var child in grid.Children)
			{
				var button = child as Button;
				button.Background = new SolidColorBrush(Colors.Transparent);
			}
		}

		private List<int> EvolveCells(List<Button> selectedCells)
		{
			var cellWithRowAndColumn = new Dictionary<int, string>();
			foreach (var cell in selectedCells)
			{
				int row = Grid.GetRow(cell);
				int column = Grid.GetColumn(cell);
				int cellNumber = ConvertGridCoordinatesIntoCellNumber(row, column);
				cellWithRowAndColumn.Add(cellNumber, string.Format("{0},{1}", row, column));
			}

			return new GenerationEngine().EvolveCells(cellWithRowAndColumn);
		}

		private int ConvertGridCoordinatesIntoCellNumber(int row, int column)
		{
			return (row * 4 + column + 1) - 1;
		}
	}
}
