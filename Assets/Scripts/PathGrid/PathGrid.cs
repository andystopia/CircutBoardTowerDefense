using GameGrid;
using UnityEngine;

namespace PathGrid
{
    public class PathGrid : PrefabGrid<PathGridItem>
    {
        private readonly EnemyPathBase path;
        private readonly IGridInstantiationCreator<PathGridItem> instantiator;

        public PathGrid(Dimensions<int> dimensions, EnemyPathBase path, PathGridItem prefab) : base(dimensions, prefab)
        {
            this.path = path;
            instantiator = new PathGridItemInstantiator();
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            var intermediateValues = path.GetExtrapolator().GetIntermediateValues();

            foreach (var enemyPathNode in intermediateValues)
            {
                // cache the location for later.
                var enemyPathNodeLocation = enemyPathNode.Location;
                var pathNodeInstance = instantiator.CreateInstance(this, enemyPathNodeLocation);

                // see if we can enable either the input or the output constraints.
                if (enemyPathNode.IncomingDirection != null)
                    pathNodeInstance.Enable(enemyPathNode.IncomingDirection.Value);
                if (enemyPathNode.OutgoingDirection != null)
                    pathNodeInstance.Enable(enemyPathNode.OutgoingDirection.Value);
                
                
                this[enemyPathNodeLocation] = pathNodeInstance;
            }
        }

    }
}