
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningSolution.Model
{
    public class CleaningPlan_Impl : ICleaningPlan
    {
        private readonly CleaningPlanDbContext Context;

        public Guid id { get; set; }
        public string title { get; set; }
        public int customerId { get; set; }
        public DateTime createdAt { get; set; }
        public string description { get; set; }

        //private List<CleaningPlan_Impl> cpiLst = new List<CleaningPlan_Impl>();

        #region Constructor

        public CleaningPlan_Impl() { }

        public CleaningPlan_Impl(CleaningPlanDbContext Context)
        {
            this.Context = Context;
        }

        public CleaningPlan_Impl(CleaningPlan c)
        {
            this.id = c.id;
            this.title = c.title;   
            this.customerId = c.customerId; 
            this.createdAt = c.createdAt;
            this.description = c.description;
        }


        #endregion


        #region Metode

        private List<CleaningPlan_Impl> AddResultToList(List<CleaningPlan> cLst)
        {
            List<CleaningPlan_Impl> cpiLst = new List<CleaningPlan_Impl>();

            foreach (CleaningPlan c in cLst)
            {
                CleaningPlan_Impl cpi = new CleaningPlan_Impl(c);
                cpiLst.Add(cpi);
            }
            
            return cpiLst;
        }

        public async Task<IEnumerable<CleaningPlan_Impl>> Get_All()
        {
            return AddResultToList(await Context.CleaningPlans.ToListAsync());
        }


        public async Task<IEnumerable<CleaningPlan_Impl>> Get_By_cId(int CustomerID)
        {
            return AddResultToList(await Context.CleaningPlans.Where(c => c.customerId == CustomerID).ToListAsync());
        }


        public async Task<CleaningPlan_Impl> Get_By_Guid(Guid guid)
        {
            var cc = await Context.CleaningPlans.FirstOrDefaultAsync(c => c.id == guid);

            return cc == null ? null : new CleaningPlan_Impl(cc);
        }


        public async Task<CleaningPlan_Impl> Add(CleaningPlan_Impl cp)
        {
            CleaningPlan cpAdd = new CleaningPlan();

            //cpAdd.id = Guid.NewGuid();
            cpAdd.title = cp.title;
            cpAdd.customerId = cp.customerId;
            cpAdd.createdAt = DateTime.Now;
            cpAdd.description = cp.description;

            var result = await Context.CleaningPlans.AddAsync(cpAdd);
            await Context.SaveChangesAsync();

            return new CleaningPlan_Impl(result.Entity);
        }


        public async Task<CleaningPlan_Impl> Update_By_Id(Guid guid, CleaningPlan_Impl cp)
        {
            var result = await Context.CleaningPlans.FirstOrDefaultAsync(c => c.id == guid);

            if(result != null)
            {

                //result.id = cp.id;
                result.title = cp.title;
                result.customerId = cp.customerId;
                //result.createdAt = DateTime.Now;
                result.description = cp.description;

                await Context.SaveChangesAsync();

                return new CleaningPlan_Impl(result);
            }

            return null;
        }


        public async Task<IEnumerable<CleaningPlan_Impl>> Delete_By_ID(int CustomerID)
        {
            var result = await Context.CleaningPlans.Where(c => c.customerId == CustomerID).ToListAsync();
            
            if(result.Count() > 0)
            {
                foreach(CleaningPlan c in result)
                    Context.CleaningPlans.Remove(c);

                await Context.SaveChangesAsync();

                return AddResultToList(result);
            }

            return null;
        }
       
        #endregion
    }
}