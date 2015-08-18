using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reorderer
{
    public class ReorderingMachine
    {
        public List<int> reorderees { get; set; }

        public ReorderingMachine()
        {
            this.reorderees = new List<int>();
        }

        public void Load(int[] anyArrayOfPositiveInts)
        {

            this.reorderees.AddRange(anyArrayOfPositiveInts);
        }


        public List<int> Reorder(int beginningOfRange, int sizeOfRange, int target)
        {
            var listToMove = this.reorderees.GetRange(beginningOfRange-1, sizeOfRange);
            var reorderedList = this.reorderees;
            reorderedList.RemoveRange(beginningOfRange-1,sizeOfRange);

            if (target > reorderedList.Count)
            {
                target = reorderedList.Count;
            }

            reorderedList.InsertRange(target, listToMove);

            return reorderedList;
        }
    }
}
