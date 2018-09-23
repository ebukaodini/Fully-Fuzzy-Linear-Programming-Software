using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fully_Fuzzy_LPP
{
    ///////////////////////////////////////////////////////////////
    // This Class is for LPP with 2 Constraints and 2 Variables
    class tableau1
    {
        // Class fields
        public int type { get; set; }
        public int cons { get; set; }
        public int vars { get; set; }
        public float[,,] tab { get; set; }
        public string[] side { get; set; }
        string[] basis = { "X1", "X2", "X3", "X4" };

        // Constructor
        public tableau1(float[,,] _tab, int _type, int _cons, int _vars, string[] _side)
        {
            tab = _tab; type = _type; cons = _cons; vars = _vars;
            side = _side;
        }

        // Converting to initial computational form
        public void toCompForm()
        {
            float[,,] ctab = tab;
            tab[0, 2, 0] = 1; tab[0, 2, 1] = 1; tab[0, 2, 2] = 1; tab[0, 2, 3] = 1;
            tab[0, 3, 0] = 0; tab[0, 3, 1] = 0; tab[0, 3, 2] = 0; tab[0, 3, 3] = 0;

            tab[1, 2, 0] = 0; tab[1, 2, 1] = 0; tab[1, 2, 2] = 0; tab[1, 2, 3] = 0;
            tab[1, 3, 0] = 1; tab[1, 3, 1] = 1; tab[1, 3, 2] = 1; tab[1, 3, 3] = 1;

            tab[2, 2, 0] = 0; tab[2, 2, 1] = 0; tab[2, 2, 2] = 0; tab[2, 2, 3] = 0;
            tab[2, 3, 0] = 0; tab[2, 3, 1] = 0; tab[2, 3, 2] = 0; tab[2, 3, 3] = 0;

            // apply the tier arrangement to the z-row only
            if (type == 1)
            {// Arranged
                for (int y = 0; y < 5; y++)
                { //element
                  // multiplying the tier in the z-row by negative
                    tab[2, y, 0] = tab[2, y, 0] * -1;
                    tab[2, y, 1] = tab[2, y, 1] * -1;
                    tab[2, y, 2] = tab[2, y, 2] * -1;
                    tab[2, y, 3] = tab[2, y, 3] * -1;
                    // Sending the new tier into a list to be sorted
                    List<float> n_tab = new List<float> {
                       tab[2, y, 0], tab[2, y, 1],
                       tab[2, y, 2], tab[2, y, 3]
                    };
                    n_tab.Sort(); n_tab.ToArray();

                    // Sending the values in the n_tab back into tab array
                    tab[2, y, 0] = n_tab[0]; tab[2, y, 1] = n_tab[1]; tab[2, y, 2] = n_tab[2]; tab[2, y, 3] = n_tab[3];
                }
            }
            else if (type == 2)
            {// Unarranged
                for (int y = 0; y < 5; y++)
                { //element
                    tab[2, y, 0] = tab[2, y, 0] * -1;
                    tab[2, y, 1] = tab[2, y, 1] * -1;

                    List<float> n_tab = new List<float> { tab[2, y, 0], tab[2, y, 1], tab[2, y, 2], tab[2, y, 3] };
                    n_tab.Sort(); n_tab.ToArray();
                    tab[2, y, 0] = n_tab[0]; tab[2, y, 1] = n_tab[1]; tab[2, y, 2] = n_tab[2]; tab[2, y, 3] = n_tab[3];

                    // flip the last two
                    float a = tab[2, y, 2];
                    tab[2, y, 2] = tab[2, y, 3];
                    tab[2, y, 3] = a;
                }
            }
        }

        // Ranking
        public void rank()
        {
            if (type == 1)
            { //Arranged
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        tab[x, y, 4] = approx((tab[x, y, 0] + tab[x, y, 1] + tab[x, y, 2] + tab[x, y, 3]) / 4);
                    }
                }
            }
            else if (type == 2)
            { //Unarranged
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        tab[x, y, 4] = approx((tab[x, y, 0] + tab[x, y, 1] + (tab[x, y, 3] - tab[x, y, 2]) / 2) / 2);
                    }
                }
            }
        }

        // Optimal?
        public bool isOptimal()
        {
            bool ans = false;
            for (int x = 0; x < 4; x++)
            {
                if (tab[2, x, 4] < 0)
                {
                    ans = false;
                    break;
                }
                else
                {
                    ans = true;
                }
            }
            return ans;
        }

        // get Pivot Column
        public int getPC()
        {
            // local array to hold the position of the column
            int pc = 0;
            //get all values into an array
            float[] pca = { tab[2, 0, 4], tab[2, 1, 4], tab[2, 2, 4], tab[2, 3, 4] };
            // Get Position
            for (int x = 0; x < 4; x++)
            {
                if (pca[x] == pca.Min())
                {
                    pc = x;
                }
            }
            return pc;
        }

        // get Pivot Row
        public int getPR(int pc)
        {
            // local array to hold the position of the column
            int pr = 0;
            //get all values into an array
            float[] pra = new float[2];
            for (int x = 0; x < 2; x++)
            {
                if (tab[x, pc, 4] == 0)
                {
                    pra[x] = 0;
                }
                else
                {
                    pra[x] = tab[x, 4, 4] / tab[x, pc, 4];
                }
            }
            //Get Position
            List<float> pre = new List<float> { pra[0], pra[1] };
            List<float> pras = new List<float> { pra[0], pra[1] };
            pras.Sort(); pras.ToArray();
            Console.WriteLine(pras[0] +","+ pras[1]);
            int i = 0;
            while (i < 2 )
            {
                if (pras[i] == 0F) { i += 1; }
                else { break; }
            }
            pr = pre.IndexOf(pras[i]);
            return pr;
        }

        // get Pivot Element
        public float getPE(int pc, int pr)
        {
            float pe = tab[pr, pc, 4];
            return pe;
        }

        // generate new tableau
        public void getNewTableau(float[,,] _tab, int pc, int pr, float pe)
        {
            float[,,] ntab = new float[3, 5, 5];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        if (pe == 0)
                        {
                            Console.WriteLine("Pivot Element Cannot be Zero.\n");
                            break;
                        }
                        else
                        {
                            //same row 
                            if (x == pr)
                            {
                                ntab[x, y, z] = approx(_tab[x, y, z] / _tab[pr, pc, z]);
                            }
                            //same column
                            else if (y == pc)
                            {
                                ntab[x, y, z] = 0;
                            }
                            //same element
                            else if (x == pr && y == pc)
                            {
                                ntab[x, y, z] = 1;
                            }
                            //else
                            else
                            {
                                ntab[x, y, z] = approx(_tab[x, y, z] - ((_tab[pr, y, z] * _tab[x, pc, z]) / _tab[pr, pc, z]));
                            }
                        }
                    }
                }
            }
            tab = ntab;
        }

        // approximate values to 2 decimal places
        private float approx(float val)
        {
            return (float)Math.Round((double)val, 2);
        }

        public void setSide()
        {
            int pc = getPC();
            int pr = getPR(pc);
            side[pr] = basis[pc];
        }
    }

    ///////////////////////////////////////////////////////////////
    // This Class is for LPP with 2 Constraints and 3 Variables
    public class tableau2
    {
        // Class fields
        public int type { get; set; }
        public int cons { get; set; }
        public int vars { get; set; }
        public float[,,] tab { get; set; }
        public string[] side { get; set; }
        string[] basis = { "X1", "X2", "X3", "X4", "X5" };

        // Constructors
        public tableau2(float[,,] _tab, int _type, int _cons, int _vars, string[] _side)
        {
            tab = _tab; type = _type; cons = _cons; vars = _vars;
            side = _side;
        }

        // Converting to initial computational form
        public void toCompForm()
        {
            float[,,] ctab = tab;
            tab[0, 3, 0] = 1; tab[0, 3, 1] = 1; tab[0, 3, 2] = 1; tab[0, 3, 3] = 1;
            tab[0, 4, 0] = 0; tab[0, 4, 1] = 0; tab[0, 4, 2] = 0; tab[0, 4, 3] = 0;

            tab[1, 3, 0] = 0; tab[1, 3, 1] = 0; tab[1, 3, 2] = 0; tab[1, 3, 3] = 0;
            tab[1, 4, 0] = 1; tab[1, 4, 1] = 1; tab[1, 4, 2] = 1; tab[1, 4, 3] = 1;

            tab[2, 3, 0] = 0; tab[2, 3, 1] = 0; tab[2, 3, 2] = 0; tab[2, 3, 3] = 0;
            tab[2, 4, 0] = 0; tab[2, 4, 1] = 0; tab[2, 4, 2] = 0; tab[2, 4, 3] = 0;

            // apply the tier arrangement to the z-row only
            if (type == 1)
            {// Arranged
                for (int y = 0; y < 6; y++)
                { //element
                  // multiplying the tier in the z-row by negative
                    tab[2, y, 0] = tab[2, y, 0] * -1;
                    tab[2, y, 1] = tab[2, y, 1] * -1;
                    tab[2, y, 2] = tab[2, y, 2] * -1;
                    tab[2, y, 3] = tab[2, y, 3] * -1;
                    // Sending the new tier into a list to be sorted
                    List<float> n_tab = new List<float> {
                       tab[2, y, 0], tab[2, y, 1],
                       tab[2, y, 2], tab[2, y, 3]
                    };
                    n_tab.Sort(); n_tab.ToArray();

                    // Sending the values in the n_tab back into tab array
                    tab[2, y, 0] = n_tab[0]; tab[2, y, 1] = n_tab[1]; tab[2, y, 2] = n_tab[2]; tab[2, y, 3] = n_tab[3];
                }
            }
            else if (type == 2)
            {// Unarranged
                for (int y = 0; y < 6; y++)
                { //element
                    tab[2, y, 0] = tab[2, y, 0] * -1;
                    tab[2, y, 1] = tab[2, y, 1] * -1;

                    List<float> n_tab = new List<float> { tab[2, y, 0], tab[2, y, 1], tab[2, y, 2], tab[2, y, 3] };
                    n_tab.Sort(); n_tab.ToArray();
                    tab[2, y, 0] = n_tab[0]; tab[2, y, 1] = n_tab[1]; tab[2, y, 2] = n_tab[2]; tab[2, y, 3] = n_tab[3];

                    // flip the last two
                    float a = tab[2, y, 2];
                    tab[2, y, 2] = tab[2, y, 3];
                    tab[2, y, 3] = a;
                }
            }
        }

        // Ranking
        public void rank()
        {
            if (type == 1)
            { //Arranged
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        tab[x, y, 4] = approx((tab[x, y, 0] + tab[x, y, 1] + tab[x, y, 2] + tab[x, y, 3]) / 4);
                    }
                }
            }
            else if (type == 2)
            { //Unarranged
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        tab[x, y, 4] = approx((tab[x, y, 0] + tab[x, y, 1] + (tab[x, y, 3] - tab[x, y, 2]) / 2) / 2);
                    }
                }
            }
        }

        // Optimal?
        public bool isOptimal()
        {
            bool ans = false;
            //tab[x,y,4];
            for (int x = 0; x < 5; x++)
            {
                if (tab[2, x, 4] < 0)
                {
                    ans = false;
                    break;
                }
                else
                {
                    ans = true;
                }
            }
            return ans;
        }

        // get Pivot Column
        public int getPC()
        {
            // local array to hold the position of the column
            int pc = 0;
            //get all values into an array
            float[] pca = { tab[2, 0, 4], tab[2, 1, 4], tab[2, 2, 4], tab[2, 3, 4], tab[2, 4, 4] };
            // Get Position
            for (int x = 0; x < 5; x++)
            {
                if (pca[x] == pca.Min())
                {
                    pc = x;
                }
            }
            return pc;
        }

        // get Pivot Row
        public int getPR(int pc)
        {
            // local array to hold the position of the column
            int pr = 0;
            //get all values into an array
            float[] pra = new float[2];
            for (int x = 0; x < 2; x++)
            {
                if (tab[x, pc, 4] == 0)
                {
                    pra[x] = 0;
                }
                else
                {
                    pra[x] = tab[x, 5, 4] / tab[x, pc, 4];
                }
            }
            //Get Position
            List<float> pre = new List<float> { pra[0], pra[1] };
            List<float> pras = new List<float> { pra[0], pra[1] };
            pras.Sort(); pras.ToArray();
            int i = 0;
            while (i < 2)
            {
                if (pras[i] == 0F) { i += 1; }
                else { break; }
            }
            pr = pre.IndexOf(pras[i]);
            return pr;
        }

        // get Pivot Element
        public float getPE(int pc, int pr)
        {
            float pe = tab[pr, pc, 4];
            return pe;
        }

        // generate new tableau
        public void getNewTableau(float[,,] _tab, int pc, int pr, float pe)
        {
            float[,,] ntab = new float[3, 6, 5];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        if (pe == 0)
                        {
                            Console.WriteLine("Pivot Element Cannot be Zero.\n");
                            break;
                        }
                        else
                        {
                            //same row 
                            if (x == pr)
                            {
                                ntab[x, y, z] = approx(_tab[x, y, z] / _tab[pr, pc, z]);
                            }
                            //same column
                            else if (y == pc)
                            {
                                ntab[x, y, z] = 0;
                            }
                            //same element
                            else if (x == pr && y == pc)
                            {
                                ntab[x, y, z] = 1;
                            }
                            //else
                            else
                            {
                                ntab[x, y, z] = approx(_tab[x, y, z] - ((_tab[pr, y, z] * _tab[x, pc, z]) / _tab[pr, pc, z]));
                                //Console.WriteLine("{0} - ( {1} * {2} / {3} ) == {4}", _tab[x,y,z],_tab[pr,y,z],_tab[x,pc,z],_tab[pr,pc,z],ntab[x,y,z]);
                            }
                        }
                    }
                }
            }
            tab = ntab;
        }

        // approximate values to 2 decimal places
        private float approx(float val)
        {
            return (float)Math.Round((double)val, 2);
        }

        // Set the side property
        public void setSide()
        {
            int pc = getPC();
            int pr = getPR(pc);
            side[pr] = basis[pc];
        }
    }

    ///////////////////////////////////////////////////////////////
    // This Class is for LPP with 3 Constraints and 2 Variables
    public class tableau3
    {
        // Class fields
        public int type { get; set; }
        public int cons { get; set; }
        public int vars { get; set; }
        public float[,,] tab { get; set; }
        public string[] side { get; set; }
        string[] basis = { "X1", "X2", "X3", "X4", "X5" };

        // Constructors
        public tableau3(float[,,] _tab, int _type, int _cons, int _vars, string[] _side)
        {
            tab = _tab; type = _type; cons = _cons; vars = _vars;
            side = _side;
        }

        // Converting to initial computational form
        public void toCompForm()
        {
            float[,,] ctab = tab;
            tab[0, 2, 0] = 1; tab[0, 2, 1] = 1; tab[0, 2, 2] = 1; tab[0, 2, 3] = 1;
            tab[0, 3, 0] = 0; tab[0, 3, 1] = 0; tab[0, 3, 2] = 0; tab[0, 3, 3] = 0;
            tab[0, 4, 0] = 0; tab[0, 4, 1] = 0; tab[0, 4, 2] = 0; tab[0, 4, 3] = 0;

            tab[1, 2, 0] = 0; tab[1, 2, 1] = 0; tab[1, 2, 2] = 0; tab[1, 2, 3] = 0;
            tab[1, 3, 0] = 1; tab[1, 3, 1] = 1; tab[1, 3, 2] = 1; tab[1, 3, 3] = 1;
            tab[1, 4, 0] = 0; tab[1, 4, 1] = 0; tab[1, 4, 2] = 0; tab[1, 4, 3] = 0;

            tab[2, 2, 0] = 0; tab[2, 2, 1] = 0; tab[2, 2, 2] = 0; tab[2, 2, 3] = 0;
            tab[2, 3, 0] = 0; tab[2, 3, 1] = 0; tab[2, 3, 2] = 0; tab[2, 3, 3] = 0;
            tab[2, 4, 0] = 1; tab[2, 4, 1] = 1; tab[2, 4, 2] = 1; tab[2, 4, 3] = 1;

            tab[3, 2, 0] = 0; tab[3, 2, 1] = 0; tab[3, 2, 2] = 0; tab[3, 2, 3] = 0;
            tab[3, 3, 0] = 0; tab[3, 3, 1] = 0; tab[3, 3, 2] = 0; tab[3, 3, 3] = 0;
            tab[3, 4, 0] = 0; tab[3, 4, 1] = 0; tab[3, 4, 2] = 0; tab[3, 4, 3] = 0;

            // apply the tier arrangement to the z-row only
            if (type == 1)
            {// Arranged
                for (int y = 0; y < 6; y++)
                { //element
                  // multiplying the tier in the z-row by negative
                    tab[3, y, 0] = tab[3, y, 0] * -1;
                    tab[3, y, 1] = tab[3, y, 1] * -1;
                    tab[3, y, 2] = tab[3, y, 2] * -1;
                    tab[3, y, 3] = tab[3, y, 3] * -1;
                    // Sending the new tier into a list to be sorted
                    List<float> n_tab = new List<float> {
                       tab[3, y, 0], tab[3, y, 1],
                       tab[3, y, 2], tab[3, y, 3]
                    };
                    n_tab.Sort(); n_tab.ToArray();

                    // Sending the values in the n_tab back into tab array
                    tab[3, y, 0] = n_tab[0]; tab[3, y, 1] = n_tab[1]; tab[3, y, 2] = n_tab[2]; tab[3, y, 3] = n_tab[3];
                }
            }
            else if (type == 2)
            {// Unarranged
                for (int y = 0; y < 6; y++)
                { //element
                    tab[3, y, 0] = tab[3, y, 0] * -1;
                    tab[3, y, 1] = tab[3, y, 1] * -1;

                    List<float> n_tab = new List<float> { tab[3, y, 0], tab[3, y, 1], tab[3, y, 2], tab[3, y, 3] };
                    n_tab.Sort(); n_tab.ToArray();
                    tab[3, y, 0] = n_tab[0]; tab[3, y, 1] = n_tab[1]; tab[3, y, 2] = n_tab[2]; tab[3, y, 3] = n_tab[3];

                    // flip the last two
                    float a = tab[3, y, 2];
                    tab[3, y, 2] = tab[3, y, 3];
                    tab[3, y, 3] = a;
                }
            }
        }

        // Ranking
        public void rank()
        {
            if (type == 1)
            { //Arranged
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        tab[x, y, 4] = approx((tab[x, y, 0] + tab[x, y, 1] + tab[x, y, 2] + tab[x, y, 3]) / 4);
                    }
                }
            }
            else if (type == 2)
            { //Unarranged
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        tab[x, y, 4] = approx((tab[x, y, 0] + tab[x, y, 1] + (tab[x, y, 3] - tab[x, y, 2]) / 2) / 2);
                    }
                }
            }
        }

        // Optimal?
        public bool isOptimal()
        {
            bool ans = false;
            //tab[x,y,4];
            for (int x = 0; x < 5; x++)
            {
                if (tab[3, x, 4] < 0)
                {
                    ans = false;
                    break;
                }
                else
                {
                    ans = true;
                }
            }
            return ans;
        }

        // get Pivot Column
        public int getPC()
        {
            // local array to hold the position of the column
            int pc = 0;
            //get all values into an array
            float[] pca = { tab[3, 0, 4], tab[3, 1, 4], tab[3, 2, 4], tab[3, 3, 4], tab[3, 4, 4] };
            // Get Position
            for (int x = 0; x < 5; x++)
            {
                if (pca[x] == pca.Min())
                {
                    pc = x;
                }
            }
            return pc;
        }

        // get Pivot Row
        public int getPR(int pc)
        {
            // local array to hold the position of the column
            int pr = 0;
            //get all values into an array
            float[] pra = new float[3];
            for (int x = 0; x < 3; x++)
            {
                if (tab[x, pc, 4] == 0)
                {
                    pra[x] = 0;
                }
                else
                {
                    pra[x] = tab[x, 5, 4] / tab[x, pc, 4];
                }
            }

            List<float> pre = new List<float> { pra[0], pra[1], pra[2] };
            List<float> pras = new List<float> { pra[0], pra[1], pra[2] };
            pras.Sort(); pras.ToArray();
            int i = 0;
            while (i < 3)
            {
                if (pras[i] == 0F) { i += 1; }
                else { break; }
            }
            pr = pre.IndexOf(pras[i]);
            return pr;
        }

        // get Pivot Element
        public float getPE(int pc, int pr)
        {
            float pe = tab[pr, pc, 4];
            return pe;
        }

        // generate new tableau
        public void getNewTableau(float[,,] _tab, int pc, int pr, float pe)
        {
            float[,,] ntab = new float[4, 6, 5];
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        if (pe == 0)
                        {
                            Console.WriteLine("Pivot Element Cannot be Zero.\n");
                            break;
                        }
                        else
                        {
                            //same row 
                            if (x == pr)
                            {
                                ntab[x, y, z] = approx(_tab[x, y, z] / _tab[pr, pc, z]);
                            }
                            //same column
                            else if (y == pc)
                            {
                                ntab[x, y, z] = 0;
                            }
                            //same element
                            else if (x == pr && y == pc)
                            {
                                ntab[x, y, z] = 1;
                            }
                            //else
                            else
                            {
                                ntab[x, y, z] = approx(_tab[x, y, z] - ((_tab[pr, y, z] * _tab[x, pc, z]) / _tab[pr, pc, z]));
                                //Console.WriteLine("{0} - ( {1} * {2} / {3} ) == {4}", _tab[x,y,z],_tab[pr,y,z],_tab[x,pc,z],_tab[pr,pc,z],ntab[x,y,z]);
                            }
                        }
                    }
                }
            }
            tab = ntab;
        }

        // approximate values to 2 decimal places
        private float approx(float val)
        {
            return (float)Math.Round((double)val, 2);
        }

        // Set the side property
        public void setSide()
        {
            int pc = getPC();
            int pr = getPR(pc);
            side[pr] = basis[pc];
        }
    }

    ///////////////////////////////////////////////////////////////
    // This Class is for LPP with 3 Constraints and 3 Variables
    public class tableau4
    {
        // Class fields
        public int type { get; set; }
        public int cons { get; set; }
        public int vars { get; set; }
        public float[,,] tab { get; set; }
        public string[] side { get; set; }
        string[] basis = { "X1", "X2", "X3", "X4", "X5", "X6" };

        // Constructors
        public tableau4(float[,,] _tab, int _type, int _cons, int _vars, string[] _side)
        {
            tab = _tab; type = _type; cons = _cons; vars = _vars;
            side = _side;
        }

        // Converting to initial computational form
        public void toCompForm()
        {
            tab[0, 3, 0] = 1; tab[0, 3, 1] = 1; tab[0, 3, 2] = 1; tab[0, 3, 3] = 1;
            tab[0, 4, 0] = 0; tab[0, 4, 1] = 0; tab[0, 4, 2] = 0; tab[0, 4, 3] = 0;
            tab[0, 5, 0] = 0; tab[0, 5, 1] = 0; tab[0, 5, 2] = 0; tab[0, 5, 3] = 0;

            tab[1, 3, 0] = 0; tab[1, 3, 1] = 0; tab[1, 3, 2] = 0; tab[1, 3, 3] = 0;
            tab[1, 4, 0] = 1; tab[1, 4, 1] = 1; tab[1, 4, 2] = 1; tab[1, 4, 3] = 1;
            tab[1, 5, 0] = 0; tab[1, 5, 1] = 0; tab[1, 5, 2] = 0; tab[1, 5, 3] = 0;

            tab[2, 3, 0] = 0; tab[2, 3, 1] = 0; tab[2, 3, 2] = 0; tab[2, 3, 3] = 0;
            tab[2, 4, 0] = 0; tab[2, 4, 1] = 0; tab[2, 4, 2] = 0; tab[2, 4, 3] = 0;
            tab[2, 5, 0] = 1; tab[2, 5, 1] = 1; tab[2, 5, 2] = 1; tab[2, 5, 3] = 1;

            tab[3, 3, 0] = 0; tab[3, 3, 1] = 0; tab[3, 3, 2] = 0; tab[3, 3, 3] = 0;
            tab[3, 4, 0] = 0; tab[3, 4, 1] = 0; tab[3, 4, 2] = 0; tab[3, 4, 3] = 0;
            tab[3, 5, 0] = 0; tab[3, 5, 1] = 0; tab[3, 5, 2] = 0; tab[3, 5, 3] = 0;

            // apply the tier arrangement to the z-row only
            if (type == 1)
            {// Arranged
                for (int y = 0; y < 7; y++)
                { //element
                  // multiplying the tier in the z-row by negative
                    tab[3, y, 0] = tab[3, y, 0] * -1;
                    tab[3, y, 1] = tab[3, y, 1] * -1;
                    tab[3, y, 2] = tab[3, y, 2] * -1;
                    tab[3, y, 3] = tab[3, y, 3] * -1;
                    // Sending the new tier into a list to be sorted
                    List<float> n_tab = new List<float> {
                       tab[3, y, 0], tab[3, y, 1],
                       tab[3, y, 2], tab[3, y, 3]
                    };
                    n_tab.Sort(); n_tab.ToArray();

                    // Sending the values in the n_tab back into tab array
                    tab[3, y, 0] = n_tab[0]; tab[3, y, 1] = n_tab[1]; tab[3, y, 2] = n_tab[2]; tab[3, y, 3] = n_tab[3];
                }
            }
            else if (type == 2)
            {// Unarranged
                for (int y = 0; y < 7; y++)
                { //element
                    tab[3, y, 0] = tab[3, y, 0] * -1;
                    tab[3, y, 1] = tab[3, y, 1] * -1;

                    List<float> n_tab = new List<float> { tab[3, y, 0], tab[3, y, 1], tab[3, y, 2], tab[3, y, 3] };
                    n_tab.Sort(); n_tab.ToArray();
                    tab[3, y, 0] = n_tab[0]; tab[3, y, 1] = n_tab[1]; tab[3, y, 2] = n_tab[2]; tab[3, y, 3] = n_tab[3];

                    // flip the last two
                    float a = tab[3, y, 2];
                    tab[3, y, 2] = tab[3, y, 3];
                    tab[3, y, 3] = a;
                }
            }
        }

        // Ranking
        public void rank()
        {
            if (type == 1)
            { //Arranged
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 7; y++)
                    {
                        tab[x, y, 4] = approx((tab[x, y, 0] + tab[x, y, 1] + tab[x, y, 2] + tab[x, y, 3]) / 4);
                    }
                }
            }
            else if (type == 2)
            { //Unarranged
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 7; y++)
                    {
                        tab[x, y, 4] = approx((tab[x, y, 0] + tab[x, y, 1] + (tab[x, y, 3] - tab[x, y, 2]) / 2) / 2);
                    }
                }
            }
        }

        // Optimal?
        public bool isOptimal()
        {
            bool ans = false;
            //tab[x,y,4];
            for (int x = 0; x < 6; x++)
            {
                if (tab[3, x, 4] < 0)
                {
                    ans = false;
                    break;
                }
                else
                {
                    ans = true;
                }
            }
            return ans;
        }

        // get Pivot Column
        public int getPC()
        {
            // local array to hold the position of the column
            int pc = 0;
            //get all values into an array
            float[] pca = { tab[3, 0, 4], tab[3, 1, 4], tab[3, 2, 4], tab[3, 3, 4], tab[3, 4, 4], tab[3, 5, 4] };
            // Get Position
            for (int x = 0; x < 6; x++)
            {
                if (pca[x] == pca.Min())
                {
                    pc = x;
                }
            }
            return pc;
        }

        // get Pivot Row
        public int getPR(int pc)
        {
            // local array to hold the position of the column
            int pr = 0;
            //get all values into an array
            float[] pra = new float[3];
            for (int x = 0; x < 3; x++)
            {
                if (tab[x, pc, 4] < 1)
                {
                    pra[x] = 0;
                }
                else
                {
                    pra[x] = tab[x, 6, 4] / tab[x, pc, 4];
                }
            }

            List<float> pre = new List<float> { pra[0], pra[1], pra[2] };
            List<float> pras = new List<float> { pra[0], pra[1], pra[2] };
            pras.Sort(); pras.ToArray();
            int i = 0;
            while (i < 3)
            {
                if (pras[i] == 0F) { i += 1; }
                else { break; }
            }
            pr = pre.IndexOf(pras[i]);
            return pr;
        }

        // get Pivot Element
        public float getPE(int pc, int pr)
        {
            float pe = tab[pr, pc, 4];
            return pe;
        }

        // generate new tableau
        public void getNewTableau(float[,,] _tab, int pc, int pr, float pe)
        {
            float[,,] ntab = new float[4, 7, 5];
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    for (int z = 0; z < 4; z++)
                    {
                        if (pe == 0)
                        {
                            Console.WriteLine("Pivot Element Cannot be Zero.\n");
                            break;
                        }
                        else
                        {
                            //same row 
                            if (x == pr)
                            {
                                ntab[x, y, z] = approx(_tab[x, y, z] / _tab[pr, pc, z]);
                            }
                            //same column
                            else if (y == pc)
                            {
                                ntab[x, y, z] = 0;
                            }
                            //same element
                            else if (x == pr && y == pc)
                            {
                                ntab[x, y, z] = 1;
                            }
                            //else
                            else
                            {
                                ntab[x, y, z] = approx(_tab[x, y, z] - ((_tab[pr, y, z] * _tab[x, pc, z]) / _tab[pr, pc, z]));
                                //Console.WriteLine("{0} - ( {1} * {2} / {3} ) == {4}", _tab[x,y,z],_tab[pr,y,z],_tab[x,pc,z],_tab[pr,pc,z],ntab[x,y,z]);
                            }
                        }
                    }
                }
            }
            tab = ntab;
        }

        // approximate values to 2 decimal places
        private float approx(float val)
        {
            return (float)Math.Round((double)val, 2);
        }

        // Set the side property
        public void setSide()
        {
            int pc = getPC();
            int pr = getPR(pc);
            side[pr] = basis[pc];
        }
    }
}
