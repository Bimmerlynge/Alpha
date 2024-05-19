using System.Collections.Generic;

namespace BuilderSystem
{
    public class BuilderController
    {
        private readonly BuilderView _view;
        private readonly BuilderModel _model;

        private BuilderController(BuilderView view, BuilderModel model)
        {
            _view = view;
            _model = model;
        }

        private void ConnectModel()
        {
            _model.ModelChanged += UpdateGrids;
        }

        private void ConnectView()
        {
            
        }

        private void UpdateGrids(IList<Grid> grids) => _view.UpdateGrids(grids);

        public class Builder
        {
            private readonly BuilderModel _model = new();

            public BuilderController Build(BuilderView view)
            {
                return new BuilderController(view, _model);
            }
        }
    }
}
