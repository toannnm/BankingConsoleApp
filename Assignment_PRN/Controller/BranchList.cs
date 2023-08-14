using Assignment.Model;
using Assignment.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Controller
{
    class BranchList
    {
        public static List<Branch> listBranch = new List<Branch>()
        {
            new Branch()
            {
                BrandID="1",BranchName="Techcombank",BrandAddress="Hochiminh",
            },
        };
        public static Branch checkDuplicateID(String branchID)
        {
            foreach (Branch bra in listBranch)
            {
                if (bra.BrandID.Equals(branchID))
                {
                    return bra;
                }
            }
            return null;
        }
        public List<Branch> Branch()
        {
            return listBranch;
        }
        public static void showBranch()
        {
            if (listBranch.Count == 0)
            {
                Inputter.yellowColor("Branch List is empty");
            }
            else
            {
                Console.WriteLine(" ------------------------");
                Console.WriteLine("-----Branch List------");
                Console.WriteLine("{0,-10} {1,-20} {2,-20}", "BranchID", "BranchName", "BrandAddress");
                foreach (Branch bra in listBranch)
                {
                    Console.WriteLine("{0,-10} {1,-20} {2,-20}", bra.BrandID, bra.BranchName, bra.BrandAddress);
                }
            }

        }
        public static void displayBranch(Branch branch)
        {
            if (listBranch.Count == 0)
            {
                Console.WriteLine("Branch List is empty");
            }
            else
            {   
                Console.WriteLine("{0,-6} {1,20} {2,20}", "BranchID", "BranchName", "BrandAddress");
                foreach (Branch bra in listBranch)
                {
                    Console.WriteLine("{0,-6} {1,20} {2,20}", bra.BrandID, bra.BranchName, bra.BrandAddress);
                }
            }

        }


    }
}

