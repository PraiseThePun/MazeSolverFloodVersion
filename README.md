Flooding a maze with the shortest number of steps to any cell.
Since the map generation was not important, the raw map is an 8x8 int array located in SolutionController.cs, this could be easily improved in the future, maybe taking the map as a parameter when doing the GET call. The map class is prepared to solve any map.
Map.ToString() could be improved, right now is hardcoded to print a 8x8 map, but since map generation was not relevant I left it as is.
