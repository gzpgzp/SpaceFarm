namespace Core.Plant
{
    public class PlantEntity
    {
        private PlantContext context;
        private Plant plantView;
        
        
        public PlantEntity(PlantContext context)
        {
            this.context = context;
        }

        public void BindView(Plant plantView)
        {
            this.plantView = plantView;
            this.plantView.BindEntity(this);
        }

        public void HarvestPlant(int now)
        {
        
        }

        //todo 如果每个植物都有更新时间会不会太多了，但是如果把成熟这个时间放在外面又不好
        public void Update(int now)
        {
            if (!context.isHarvested && now >= context.harvestTime)
            {
                context.isHarvested = true;
            }
        }
    }
}