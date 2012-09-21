using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPxP.Helper;

namespace NPxP
{
    public partial class FailPieceList : Form
    {
        #region Local Variables

        private MapWindow _mp;
        private DataTable _dtbFlaws;
        private string _originRowFilter;
        private List<bool> _doffResult;
        private bool btnPrevPieceStatus, btnNextPieceStatus;
        private List<double> _cuts;
        private Label _originCurrentPageLabel;
        private int _originCurrentPage;
        private Color _originCurrentPageColor;

        #endregion

        #region Constructor

        public FailPieceList(MapWindow mp, ref DataTable dtbFlaws, List<bool> doffResult, List<double> cuts,Label currentPage)
        {
            InitializeComponent();
            this._mp = mp;
            this._dtbFlaws = dtbFlaws;
            this._doffResult = doffResult;
            this._cuts = cuts;
            this._originCurrentPageLabel = currentPage;
            _originCurrentPage = Convert.ToInt32(_originCurrentPageLabel.Text);
            _originCurrentPageColor = _originCurrentPageLabel.ForeColor;
        }

        ~FailPieceList()
        {

        }

        #endregion

        #region Action Events

        private void FailList_Load(object sender, EventArgs e)
        {
            // Setting button status
            btnPrevPieceStatus = _mp.btnPrevPiece.Enabled;
            btnNextPieceStatus = _mp.btnNextPiece.Enabled;
            _mp.btnPrevPiece.Enabled = false;
            _mp.btnNextPiece.Enabled = false;
            _originRowFilter = _dtbFlaws.DefaultView.RowFilter;

            int i = 0;
            foreach (bool result in _doffResult)
            {
                if (result == false)
                {
                    double topOfPart = _cuts[i] - JobHelper.PxPInfo.Height;
                    double bottomOfPart = _cuts[i];
                    string filterExp = String.Format("MD > {0} AND MD < {1}", topOfPart, bottomOfPart);
                                
                    dgvFailPieceList.Rows.Add(i + 1, _dtbFlaws.Select(filterExp).Length);
                }
                i++;
            }
        }

        private void gvFailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int pieceNumber = (int)dgvFailPieceList.Rows[e.RowIndex].Cells[0].Value;
            changePiece(pieceNumber);
            _originCurrentPageLabel.Text = pieceNumber.ToString();
            _originCurrentPageLabel.ForeColor = Color.Red;
        }

        private void FailList_FormClosing(object sender, FormClosingEventArgs e)
        {
            changePiece(_originCurrentPage);
            _mp.btnPrevPiece.Enabled = btnPrevPieceStatus;
            _mp.btnNextPiece.Enabled = btnNextPieceStatus;
            _originCurrentPageLabel.Text = _originCurrentPage.ToString();
            _originCurrentPageLabel.ForeColor = _originCurrentPageColor;
        }

        private void changePiece(int pieceNumber)
        {
            double topOfPart = _cuts[pieceNumber - 1] - JobHelper.PxPInfo.Height;
            double bottomOfPart = _cuts[pieceNumber - 1];
            string filterExp = String.Format("MD > {0} AND MD < {1}", topOfPart, bottomOfPart);

            DataView dv = _dtbFlaws.DefaultView;
            dv.RowFilter = filterExp;
            _mp.DrawChartPoint(topOfPart);
        }

        #endregion
    }
}