namespace GameGrid
{
    /// <summary>
    /// Represents a behavior which can
    /// instantiate objects given their position
    /// in a grid.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGridInstantiationCreator<T>
    {
        /// <summary>
        /// Defines the method that allows the creation
        /// of a prefab instance.
        /// 
        /// </summary>
        /// <param name="grid"> the grid that is having it's object instantiated</param>
        /// <param name="location"> where in the grid the instance is </param>
        /// <returns></returns>
        public T CreateInstance(PrefabGrid<T> grid, Location<int> location);
    }
}