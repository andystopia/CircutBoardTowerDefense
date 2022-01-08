namespace GameGrid
{
    /// <summary>
    /// Represents a grid with an associated prefab object.
    /// This grid can only be filled with types which are
    /// covariant with the associated object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PrefabGrid<T> : GameObjectGrid<T>
    {
        public T Prefab { get; }


        /// <summary>
        /// Creates a new grid with an associated prefab
        /// object.
        /// </summary>
        /// <param name="dimensions"> the dimensions of the grid</param>
        /// <param name="prefab"> the associated prefab </param>
        protected PrefabGrid(Dimensions<int> dimensions, T prefab) : base(dimensions)
        {
            Prefab = prefab;
        }

        /// <summary>
        /// Creates a new grid abstract from a concrete array
        /// with an associated prefab.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="prefab"></param>
        protected PrefabGrid(T[,] items, T prefab) : base(items)
        {
            Prefab = prefab;
        }

        /// <summary>
        /// Assigns every location in the board, to the value
        /// returned by the <c>CreateInstance</c> method of
        /// the <param name="instantiationCreator"></param>.
        ///
        /// This allows for population of the game board,
        /// and for prefab objects to be instantiated.
        /// </summary>
        /// <param name="instantiationCreator"></param>
        protected void GridInstantiate(IGridInstantiationCreator<T> instantiationCreator)
        {
            foreach (var loc in RowMajorIEnumerator())
            {
                this[loc] = instantiationCreator.CreateInstance(this, loc);
            }
        }
    }
}