using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinetry
{
    public class Cabinet
    {
        private _Size size = new _Size();
        public _Size Size
        {
            get { return size; }
            set { size = value; }
        }
        private bool isBackFinished = false;
        public bool HasBack
        {
            get { return isBackFinished; }
            set { isBackFinished = value; }
        }
        private bool hasLocks = false;
        public bool HasLocks
        {
            get { return hasLocks; }
            set { hasLocks = value; }
        }
        private List<List<Drawer>> bankOfdrawers = new List<List<Drawer>>();
        public List<List<Drawer>> BankOfDrawers
        {
            get { return bankOfdrawers; }
            set { bankOfdrawers = value; }
        }
        private List<Door> doors = new List<Door>();
        public List<Door> Doors
        {
            get { return doors; }
            set { doors = value; }
        }
        public int NumberOfDoors
        {
            get { return Doors.Count; }
        }
        private int numberOfFullDrawers = 0;
        public int NumberOfFullDrawers
        {
            get { return numberOfFullDrawers; }
            set { numberOfFullDrawers = value; }
        }
        private int numberOfHalfDrawers = 0;
        public int NumberOfHalfDrawers
        {
            get { return numberOfHalfDrawers; }
            set { numberOfHalfDrawers = value; }
        }
        private int numberOfFileDrawers = 0;
        public int NumberOfFileDrawers
        {
            get { return numberOfFileDrawers; }
            set { numberOfFileDrawers = value; }
        }
    }
    public class _Size
    {
        private double depth = 0;
        public double Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        private double width = 0;
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        private double height = 0;
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
    }
    public enum LeftOrRight
    {
        Right,
        Left
    }
    public class Door
    {
        private LeftOrRight hingeSide = new LeftOrRight();
        public LeftOrRight HingeSide
        {
            get { return hingeSide; }
            set { hingeSide = value; }
        }

    }
    public class Drawer
    {
        private _Size size = new _Size();
        public _Size Size
        {
            get { return size; }
            set { size = value; }
        }
        public _FrontCondition Front = new _FrontCondition();
        public enum _FrontCondition
        {
            Inset,
            Flush
        }
        public _Slide Slide = new _Slide();

        public enum _Slide
        {
            Standard,
            Soft_Close
        }
    }
    public class Hinges
    {
        public enum HingeType
        {
            Inset,
            Flush
        }
    }
    public class Catch
    {
        public enum CatchType
        {
            Magnetic,
            Roller
        }
    }
    public class Caster
    {
        public enum _casterSize
        {
            _3,
            _2
        }
    }
    public class Pulls
    {
        public enum PullType
        {
            Rectangular_brushed_aluminum,
            Aluminum_wire,
            Stainless_steel_wire,
            Recessed_aluminum,
            Painted_recessed_aluminum
        }
    }
    public class LabelHolder
    {
        public enum LabelHolderType
        {
            None,
            One_on_each_door_and_drawer,
            One_per_pair_of_doors_and_each_drawer
        }
    }
    public class GlassFramedDoors
    {
        public enum GlasssFramedDoorType
        {
            _3__16___inch_clear_float_glass,
            _1__4___inch_laminated_safety_glass,
            _1__4___inch_tempered_safety_glass
        }
    }
    public class SecurityPanel
    {
        public enum SecurityPanelType
        {
            Without_security_panel,
            With_security_panel
        }
    }
    public class Identifier
    {
        public string ItemNumber
        {
            get
            {
                string _result = "S";
                _result = _result + Type.ToString() + thisCabinet.Size.Height.ToString() + thisCabinet.Size.Width.ToString();
                _result = _result + thisCabinet.NumberOfDoors.ToString() + thisCabinet.NumberOfFullDrawers.ToString() + thisCabinet.NumberOfHalfDrawers.ToString();
                if (thisCabinet.NumberOfDoors == 1)
                {
                    if (thisCabinet.Doors[0].HingeSide == LeftOrRight.Left) { _result = _result + "L"; }
                    if (thisCabinet.Doors[0].HingeSide == LeftOrRight.Right) { _result = _result + "R"; }
                }
                if (thisCabinet.HasLocks) { _result = _result + "-LK"; }
                if (thisCabinet.HasBack) { _result = _result + "-FB"; }
                if(thisCabinet.NumberOfFileDrawers > 0) { _result = _result + "-" + thisCabinet.NumberOfFileDrawers.ToString() + "F"; }
                return _result;
            }
        }
        public Identifier() { }
        public Identifier(Cabinet _c)
        { thisCabinet = _c; }
        private Cabinet thisCabinet = new Cabinet();
        private _Type type = new _Type();
        public _Type Type
        {
            get { return type; }
            set { type = value; }
        }
        private string TypeCode
        {
            get
            {
                switch(type)
                {
                    default:
                        return "Base";
                    case _Type.F:
                        return "Floor";
                    case _Type.HB:
                        return "Hanging Base";
                    case _Type.OB:
                        return "Overlay Base";
                    case _Type.MB:
                        return "Mobile Base";
                    case _Type.W:
                        return "Wall";
                    case _Type.ASB:
                        return "Acid Storage Base";
                    case _Type.FSB:
                        return "Flammable Storage";
                }
            }
        }
        public string HeightCode
        {
            get { return thisCabinet.Size.Height.ToString(); }
        }
        public string WdithCode
        {
            get { return thisCabinet.Size.Width.ToString(); }
        }
        public enum _Type
        {
            B,
            F,
            HB,
            OB,
            MB,
            W,
            ASB,
            FSB
        }
        public enum BaseCabinetHeight
        {
            Undefined,
            Sitting,
            ADA,
            Standing,
            Special
        }
    }
}
