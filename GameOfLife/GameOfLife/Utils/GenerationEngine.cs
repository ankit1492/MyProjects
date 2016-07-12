using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Utils
{
	public class GenerationEngine
	{
		public List<int> EvolveCells(Dictionary<int, string> selectedCellsWithRowAndColumn)
		{
			var evolvedCells = new List<int>();
			foreach (var cell in selectedCellsWithRowAndColumn)
			{
				var neighbours = GetNeighbours(cell);

				if (WillCellSurvive(neighbours, selectedCellsWithRowAndColumn))
					evolvedCells.Add(cell.Key);
			}

			return evolvedCells;
		}

		private bool WillCellSurvive(List<int> neighbours, Dictionary<int, string> selectedCellsWithRowAndColumn)
		{

			if (selectedCellsWithRowAndColumn.Keys.Intersect(neighbours).Count() < 2)
				return false;
			if (selectedCellsWithRowAndColumn.Keys.Intersect(neighbours).Count() >= 2 && selectedCellsWithRowAndColumn.Keys.Intersect(neighbours).Count() <= 3)
				return true;
			if (selectedCellsWithRowAndColumn.Keys.Intersect(neighbours).Count() > 3)
				return false;
			return false;
		}

		private List<int> GetNeighbours(KeyValuePair<int, string> cell)
		{
			var neighbours = new List<int>();

			var cellRowColumn = cell.Value.Split(',');
			var row = Convert.ToInt32(cellRowColumn[0]);
			var column = Convert.ToInt32(cellRowColumn[1]);

			neighbours.Add((row - 1) * 4 + column - 1);
			neighbours.Add((row - 1) * 4 + column);
			neighbours.Add((row - 1) * 4 + column + 1);
			neighbours.Add(row * 4 + column - 1);
			neighbours.Add(row * 4 + column + 1);
			neighbours.Add((row + 1) * 4 + column - 1);
			neighbours.Add((row + 1) * 4 + column);
			neighbours.Add((row + 1) * 4 + column + 1);

			return neighbours;
		}
	}
}
