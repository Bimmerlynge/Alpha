using System;
using System.Collections.Generic;
using Helpers;


namespace BuilderSystem
{
    public class BuilderModel : IBuilderModel
    {
        public event Action<IList<Grid>> ModelChanged = delegate { };
        
        public List<Grid> _grids;

        public BuilderModel()
        {
            
        }


        public void Init()
        {
            _grids[0].GridChanged += HandleGridChange;
        }

        private void HandleGridChange()
        {
            ModelChanged.Invoke(_grids);
        }

        public void PlaceTower()
        {
            
        }
    }

    
}

