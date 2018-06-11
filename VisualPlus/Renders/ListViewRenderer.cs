namespace VisualPlus.Renders
{
    #region Namespace

    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;

    using VisualPlus.Enumerators;
    using VisualPlus.Managers;
    using VisualPlus.Native;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.Child;
    using VisualPlus.Toolkit.Controls.DataManagement;
    using VisualPlus.Toolkit.Controls.DataManagement.ListViewComponents;

    using ContentAlignment = System.Drawing.ContentAlignment;

    #endregion

    public static class ListViewRenderer
    {
        #region Methods

        /// <summary>Draw the contents of a cell, do not draw any background or associated things.</summary>
        /// <param name="graphicsCell">The graphics cell.</param>
        /// <param name="rectCell">The rectangle cell.</param>
        /// <param name="img">The image.</param>
        /// <param name="alignment">The alignment.</param>
        /// <param name="cellPaddingSize">The Cell Padding Size.</param>
        /// <param name="listView">The list View.</param>
        /// <returns>Returns the area of the cell that is left for you to put anything else on.</returns>
        public static Rectangle DrawCellGraphic(Graphics graphicsCell, Rectangle rectCell, Image img, HorizontalAlignment alignment, int cellPaddingSize, VisualListViewAdvanced listView)
        {
            int th;
            int ty;
            int tw;
            int tx;

            th = img.Height + (cellPaddingSize * 2);
            tw = img.Width + (cellPaddingSize * 2);
            listView.MaxHeight = th; // this will only set if auto-size is true

            if ((tw > rectCell.Width) || (th > rectCell.Height))
            {
                return rectCell; // not enough room to draw the image, bail out
            }

            if (alignment == HorizontalAlignment.Left)
            {
                ty = rectCell.Y + cellPaddingSize + ((rectCell.Height - th) / 2);
                tx = rectCell.X + cellPaddingSize;

                graphicsCell.DrawImage(img, tx, ty);

                // remove the width that we used for the graphic from the cell
                rectCell.Width -= img.Width + (cellPaddingSize * 2);
                rectCell.X += tw;
            }
            else if (alignment == HorizontalAlignment.Center)
            {
                ty = rectCell.Y + cellPaddingSize + ((rectCell.Height - th) / 2);
                tx = rectCell.X + cellPaddingSize + ((rectCell.Width - tw) / 2);

                graphicsCell.DrawImage(img, tx, ty);

                // remove the width that we used for the graphic from the cell
                // rectCell.Width -= (img.Width + (CellPaddingSize*2));
                // rectCell.X += (img.Width + (CellPaddingSize*2));
                rectCell.Width = 0;
            }
            else if (alignment == HorizontalAlignment.Right)
            {
                ty = rectCell.Y + cellPaddingSize + ((rectCell.Height - th) / 2);
                tx = rectCell.Right - tw;

                graphicsCell.DrawImage(img, tx, ty);

                // remove the width that we used for the graphic from the cell
                rectCell.Width -= tw;
            }

            return rectCell;
        }

        /// <summary>Draw cell text is used by header and cell to draw properly aligned text in subitems.</summary>
        /// <param name="graphics">The graphics cell.</param>
        /// <param name="rectangle">The rectangle cell.</param>
        /// <param name="cellText">The text of the cell.</param>
        /// <param name="font">The font.</param>
        /// <param name="alignment">The alignment.</param>
        /// <param name="textColor">The text color.</param>
        /// <param name="selected">The selected toggle.</param>
        /// <param name="listView">The list View.</param>
        public static void DrawCellText(Graphics graphics, Rectangle rectangle, string cellText, Font font, ContentAlignment alignment, Color textColor, bool selected, VisualListViewAdvanced listView)
        {
            int _interiorWidth = rectangle.Width - (listView.CellPaddingSize * 2);

            // int _interiorHeight = rectangle.Height - (cellPaddingSize * 2);
            DebugTraceManager.WriteDebug("ListViewRenderer::DrawCellText - CellText: " + cellText, DebugTraceManager.DebugOutput.TraceListener);

            // Convert property editor friendly alignment to an alignment we can use for strings
            StringFormat _stringFormat = new StringFormat
                {
                    Alignment = TextManager.ConvertContentAlignmentToStringAlignment(alignment, Orientation.Horizontal),
                    LineAlignment = TextManager.ConvertContentAlignmentToStringAlignment(alignment, Orientation.Vertical)
                };
            SizeF _measuredSize;
            if (listView.HeaderWordWrap)
            {
                // word wrapping is on by default for drawing
                _stringFormat.FormatFlags = 0;
                _measuredSize = graphics.MeasureString(cellText, font, new Point(listView.CellPaddingSize, listView.CellPaddingSize), _stringFormat);
            }
            else
            {
                // they aren't word wrapping so we need to put the ...'s where necessary
                _stringFormat.FormatFlags = StringFormatFlags.NoWrap;
                _measuredSize = graphics.MeasureString(cellText, font, new Point(listView.CellPaddingSize, listView.CellPaddingSize), _stringFormat);
                if (_measuredSize.Width > _interiorWidth)
                {
                    // Don't truncate if we are doing word wrap
                    cellText = TextManager.TruncateString(cellText, font, _interiorWidth, graphics);
                }
            }

            // This will only set if auto - size is true
            listView.MaxHeight = (int)_measuredSize.Height + (listView.CellPaddingSize * 2);
            graphics.DrawString(cellText, font, new SolidBrush(textColor), rectangle /*rectCell.X+this.CellPaddingSize, rectCell.Y+this.CellPaddingSize*/, _stringFormat);
        }

        /// <summary>Draw a checkbox on the sub item.</summary>
        /// <param name="graphicsCell">The graphics cell.</param>
        /// <param name="rectCell">The rectangle cell.</param>
        /// <param name="checkToggle">The checked cell.</param>
        /// <param name="checkBoxSize">The check Box Size.</param>
        /// <param name="listView">The list View.</param>
        /// <returns>The <see cref="Rectangle" />.</returns>
        public static Rectangle DrawCheckBox(Graphics graphicsCell, Rectangle rectCell, bool checkToggle, int checkBoxSize, VisualListViewAdvanced listView)
        {
            int th = checkBoxSize + (listView.CellPaddingSize * 2);
            int tw = checkBoxSize + (listView.CellPaddingSize * 2);
            listView.MaxHeight = th; // this will only set if auto-size is true

            if ((tw > rectCell.Width) || (th > rectCell.Height))
            {
                return rectCell; // not enough room to draw the image, bail out
            }

            int ty = rectCell.Y + listView.CellPaddingSize + ((rectCell.Height - th) / 2);
            int tx = rectCell.X + listView.CellPaddingSize;

            Point _location = new Point(tx, ty);

            if (checkToggle)
            {
                // Checked
                // graphicsCell.DrawImage(listView.ImageList.Images[1], tx, ty);
                // graphicsCell.FillRectangle( Brushes.YellowGreen, tx, ty, checkBoxSize, checkBoxSize);
                CheckBoxRenderer.DrawCheckBox(graphicsCell, _location, CheckBoxState.CheckedNormal);
            }
            else
            {
                // Unchecked
                // graphicsCell.DrawImage(listView.ImageList.Images[0], tx, ty);
                // graphicsCell.FillRectangle( Brushes.Red, tx, ty, checkBoxSize, checkBoxSize);
                CheckBoxRenderer.DrawCheckBox(graphicsCell, _location, CheckBoxState.UncheckedNormal);
            }

            // Remove the width that we used for the graphic from the cell
            rectCell.Width -= checkBoxSize + (listView.CellPaddingSize * 2);
            rectCell.X += tw;

            return rectCell;
        }

        /// <summary>Draw column in header control.</summary>
        /// <param name="graphicsColumn">The graphics column.</param>
        /// <param name="rectColumn">The rectangle column.</param>
        /// <param name="column">The column.</param>
        /// <param name="theme">The _theme.</param>
        /// <param name="listView">The list View.</param>
        public static void DrawColumnHeader(Graphics graphicsColumn, Rectangle rectColumn, VisualListViewColumn column, IntPtr theme, VisualListViewAdvanced listView)
        {
            DebugTraceManager.WriteDebug("ListViewRenderer::DrawColumnHeader - Name: " + column.Name, DebugTraceManager.DebugOutput.TraceListener);

            if (listView.ControlStyle == LVControlStyles.SuperFlat)
            {
                SolidBrush brush = new SolidBrush(listView.SuperFlatHeaderColor);
                graphicsColumn.FillRectangle(brush, rectColumn);
                brush.Dispose();
            }
            else if ((listView.ControlStyle == LVControlStyles.XP) && listView.ThemesAvailable)
            {
                // this is really the only thing we care about for themeing right now inside the control
                IntPtr hDC = graphicsColumn.GetHdc();

                RECT colrect = new RECT(rectColumn.X, rectColumn.Y, rectColumn.Right, rectColumn.Bottom);
                RECT cliprect = new RECT(rectColumn.X, rectColumn.Y, rectColumn.Right, rectColumn.Bottom);

                if (column.State == ColumnStates.None)
                {
                    // Debug.WriteLine( "Normal" );
                    Uxtheme.DrawThemeBackground(theme, hDC, 1, 1, ref colrect, ref cliprect);
                }
                else if (column.State == ColumnStates.Pressed)
                {
                    // Debug.WriteLine( "Pressed" );
                    Uxtheme.DrawThemeBackground(theme, hDC, 1, 3, ref colrect, ref cliprect);
                }
                else if (column.State == ColumnStates.Hot)
                {
                    // Debug.WriteLine( "Hot" );
                    Uxtheme.DrawThemeBackground(theme, hDC, 1, 2, ref colrect, ref cliprect);
                }

                graphicsColumn.ReleaseHdc(hDC);
            }
            else
            {
                // normal state
                if (column.State != ColumnStates.Pressed)
                {
                    ControlPaint.DrawButton(graphicsColumn, rectColumn, ButtonState.Normal);
                }
                else
                {
                    ControlPaint.DrawButton(graphicsColumn, rectColumn, ButtonState.Pushed);
                }
            }

            // if there is an image, this routine will RETURN with exactly the space left for everything else after the image is drawn (or not drawn due to lack of space)
            if ((column.ImageIndex > -1) && (listView.ImageList != null) && (column.ImageIndex < listView.ImageList.Images.Count))
            {
                rectColumn = DrawCellGraphic(graphicsColumn, rectColumn, listView.ImageList.Images[column.ImageIndex], HorizontalAlignment.Left, listView.CellPaddingSize, listView);
            }

            DrawCellText(graphicsColumn, rectColumn, column.Text, listView.Font, column.TextAlignment, listView.ForeColor, false, listView);
        }

        /// <summary>Draw the column header.</summary>
        /// <param name="graphicHeader">The graphics header.</param>
        /// <param name="sizeHeader">The size header.</param>
        /// <param name="listView">The list View.</param>
        /// <param name="hPanelScrollBar">The h Panel Scroll Bar.</param>
        /// <param name="theme">The theme.</param>
        public static void DrawColumnHeader(Graphics graphicHeader, Size sizeHeader, VisualListViewAdvanced listView, ManagedHScrollBar hPanelScrollBar, IntPtr theme)
        {
            DebugTraceManager.WriteDebug("ListViewRenderer::DrawHeader", DebugTraceManager.DebugOutput.TraceListener);

            if (listView.ControlStyle == LVControlStyles.SuperFlat)
            {
                SolidBrush brush = new SolidBrush(listView.SuperFlatHeaderColor);
                graphicHeader.FillRectangle(brush, listView.HeaderRect);
                brush.Dispose();
            }
            else
            {
                graphicHeader.FillRectangle(SystemBrushes.Control, listView.HeaderRect);
            }

            if (listView.Columns.Count <= 0)
            {
                return;
            }

            // draw vertical lines first, then horizontal lines
            int nCurrentX = -hPanelScrollBar.Value + listView.HeaderRect.X;
            foreach (VisualListViewColumn column in listView.Columns)
            {
                // cull columns that won't be drawn first
                if (nCurrentX + column.Width < 0)
                {
                    nCurrentX += column.Width;
                    continue; // skip this column, its not being drawn
                }

                if (nCurrentX > listView.HeaderRect.Right)
                {
                    return; // were past the end of the visible column, stop drawing
                }

                if (column.Width > 0)
                {
                    DrawColumnHeader(graphicHeader, new Rectangle(nCurrentX, listView.HeaderRect.Y, column.Width, listView.HeaderHeight), column, theme, listView);
                }

                nCurrentX += column.Width; // move the parser
            }
        }

        /// <summary>Draw grid lines in client area.</summary>
        /// <param name="rowsDC">Graphics dc.</param>
        /// <param name="vPanelScrollBar">The v Panel Scroll Bar.</param>
        /// <param name="hPanelScrollBar">The h Panel Scroll Bar.</param>
        /// <param name="listView">The list View.</param>
        public static void DrawGridLines(Graphics rowsDC, ManagedVScrollBar vPanelScrollBar, ManagedHScrollBar hPanelScrollBar, VisualListViewAdvanced listView)
        {
            DebugTraceManager.WriteDebug("ListViewRenderer::DrawGridLines", DebugTraceManager.DebugOutput.TraceListener);

            // int _startItem = vPanelScrollBar.Value;
            // int _yCursor = rect.Y;
            int _yCursor = listView.RowsInnerClientRect.Y;
            using (Pen _gridPen = new Pen(listView.GridColor))
            {
                if (listView.GridLineStyle == GridLineStyle.Dashed)
                {
                    _gridPen.DashStyle = DashStyle.Dash;
                }
                else if (listView.GridLineStyle == GridLineStyle.Solid)
                {
                    _gridPen.DashStyle = DashStyle.Solid;
                }
                else
                {
                    _gridPen.DashStyle = DashStyle.Solid;
                }

                if ((listView.GridLines == GridLines.Both) || (listView.GridLines == GridLines.Horizontal))
                {
                    int _rowsToDraw = listView.VisibleRowsCount + 1;
                    if (listView.GridTypes == GridTypes.Exists)
                    {
                        if (listView.VisibleRowsCount > listView.Count)
                        {
                            _rowsToDraw = listView.Count;
                        }
                    }

                    for (var _item = 0; _item < _rowsToDraw; _item++)
                    {
                        _yCursor += listView.ItemHeight;

                        // draw horizontal line
                        rowsDC.DrawLine(_gridPen, 0, _yCursor, listView.RowsInnerClientRect.Width, _yCursor);
                    }
                }

                if ((listView.GridLines == GridLines.Both) || (listView.GridLines == GridLines.Vertical))
                {
                    int _xCursor = -hPanelScrollBar.Value;
                    for (var column = 0; column < listView.Columns.Count; column++)
                    {
                        _xCursor += listView.Columns[column].Width;
                        rowsDC.DrawLine(_gridPen, _xCursor + 1, listView.RowsInnerClientRect.Y, _xCursor + 1, listView.RowsInnerClientRect.Bottom); // draw vertical line
                    }
                }
            }
        }

        /// <summary>Draw row at specified coordinates.</summary>
        /// <param name="graphicsRow">The graphics row.</param>
        /// <param name="rectRow">The rectangle row.</param>
        /// <param name="item">The item.</param>
        /// <param name="itemIndex">The item index.</param>
        /// <param name="listView">The list View.</param>
        /// <param name="hPanelScrollBar">The h Panel Scroll Bar.</param>
        /// <param name="_newLiveControls">The _new Live Controls.</param>
        /// <param name="_liveControls">The _live Controls.</param>
        /// <param name="checkBoxSize">The check Box Size.</param>
        public static void DrawRow(Graphics graphicsRow, Rectangle rectRow, VisualListViewItem item, int itemIndex, VisualListViewAdvanced listView, ManagedHScrollBar hPanelScrollBar, ArrayList _newLiveControls, ArrayList _liveControls, int checkBoxSize)
        {
            DebugTraceManager.WriteDebug("ListViewRenderer::DrawRow", DebugTraceManager.DebugOutput.TraceListener);

            // If its selected, that trumps all, if not then see if we are using alternating colors, if not draw normal
            // this can all be overridden by the sub item background property make sure anything can even be selected before drawing selection rectangles
            if (item.Selected && listView.Selectable)
            {
                using (SolidBrush _brushBackground = new SolidBrush(Color.FromArgb(255, listView.SelectionColor.R, listView.SelectionColor.G, listView.SelectionColor.B)))
                {
                    if (!listView.FullRowSelect)
                    {
                        // Calculate how far into the control it goes
                        int _widthDepth = -hPanelScrollBar.Value + listView.Columns.Width;
                        graphicsRow.FillRectangle(_brushBackground, listView.RowsInnerClientRect.X, rectRow.Y, _widthDepth, rectRow.Height);
                    }
                    else
                    {
                        graphicsRow.FillRectangle(_brushBackground, listView.RowsInnerClientRect.X, rectRow.Y, listView.RowsInnerClientRect.Width, rectRow.Height);
                    }
                }
            }
            else
            {
                // If the back color of the list doesn't match the back color of the item (AND) the back color isn't white, then override it
                if ((item.BackColor.ToArgb() != listView.BackColor.ToArgb()) && (item.BackColor != Color.White))
                {
                    using (SolidBrush _backgroundBrush = new SolidBrush(item.BackColor))
                    {
                        graphicsRow.FillRectangle(_backgroundBrush, listView.RowsInnerClientRect.X, rectRow.Y, listView.RowsInnerClientRect.Width, rectRow.Height);
                    }
                }
                else if (listView.AlternatingColors)
                {
                    // Check for full row alternate color alternating colors are only shown if the row isn't selected.
                    int _alternateItemIndex = listView.Items.FindItemIndex(item);
                    if (_alternateItemIndex % 2 > 0)
                    {
                        using (SolidBrush _backgroundBrush = new SolidBrush(listView.AlternateBackground))
                        {
                            if (!listView.FullRowSelect)
                            {
                                // Calculate how far into the control it goes
                                int _widthDepth = -hPanelScrollBar.Value + listView.Columns.Width;
                                graphicsRow.FillRectangle(_backgroundBrush, listView.RowsInnerClientRect.X, rectRow.Y, _widthDepth, rectRow.Height);
                            }
                            else
                            {
                                graphicsRow.FillRectangle(_backgroundBrush, listView.RowsInnerClientRect.X, rectRow.Y, listView.RowsInnerClientRect.Width, rectRow.Height);
                            }
                        }
                    }
                }
            }

            int xCursor = -hPanelScrollBar.Value + listView.BorderPadding;
            for (var subItemIndex = 0; subItemIndex < listView.Columns.Count; subItemIndex++)
            {
                Rectangle _subItemRectangle = new Rectangle(xCursor, rectRow.Y, listView.Columns[subItemIndex].Width, rectRow.Height);

                // Avoid drawing items that are not in the visible region
                if ((_subItemRectangle.Right < 0) || (_subItemRectangle.Left > listView.RowsInnerClientRect.Right))
                {
                    Debug.Write(string.Empty);
                }
                else
                {
                    DrawSubItem(graphicsRow, _subItemRectangle, item, item.SubItems[subItemIndex], subItemIndex, listView.Font, listView, _newLiveControls, _liveControls, listView.CellPaddingSize, checkBoxSize);
                }

                xCursor += listView.Columns[subItemIndex].Width;
            }

            // Post draw for focus rect and hot tracking
            if ((itemIndex == listView.HotItemIndex) && listView.HotItemTracking)
            {
                // handle hot tracking of items
                Color transparentColor = Color.FromArgb(75, listView.HotTrackingColor.R, listView.HotTrackingColor.G, listView.HotTrackingColor.B); // 182, 189, 210 );
                using (Brush hotBrush = new SolidBrush(transparentColor))
                {
                    graphicsRow.FillRectangle(hotBrush, listView.RowsInnerClientRect.X, rectRow.Y, listView.RowsInnerClientRect.Width, rectRow.Height);
                }
            }

            // Draw row borders
            if (item.RowBorderSize > 0)
            {
                using (Pen _borderPen = new Pen(item.RowBorderColor, item.RowBorderSize) { Alignment = PenAlignment.Inset })
                {
                    graphicsRow.DrawRectangle(_borderPen, rectRow);
                }
            }

            // Make sure anything can even be selected before drawing selection rects
            if (listView.Selectable)
            {
                if (listView.ShowFocusRect && (listView.FocusedItem == item))
                {
                    // Deal with focus rect
                    ControlPaint.DrawFocusRectangle(graphicsRow, new Rectangle(listView.RowsInnerClientRect.X + 1, rectRow.Y, listView.RowsInnerClientRect.Width - 1, rectRow.Height));
                }
            }
        }

        /// <summary>Draw client rows of list control.</summary>
        /// <param name="graphicsRows">The graphics row.</param>
        /// <param name="listView">The list View.</param>
        /// <param name="vPanelScrollBar">The v Panel Scroll Bar.</param>
        /// <param name="hPanelScrollBar">The h Panel Scroll Bar.</param>
        /// <param name="_newLiveControls">The new Live Controls.</param>
        /// <param name="_liveControls">The live Controls.</param>
        /// <param name="checkBoxSize">The check Box Size.</param>
        public static void DrawRows(Graphics graphicsRows, VisualListViewAdvanced listView, ManagedVScrollBar vPanelScrollBar, ManagedHScrollBar hPanelScrollBar, ArrayList _newLiveControls, ArrayList _liveControls, int checkBoxSize)
        {
            DebugTraceManager.WriteDebug("ListViewRenderer::DrawRows", DebugTraceManager.DebugOutput.TraceListener);

            SolidBrush brush = new SolidBrush(listView.BackColor);
            graphicsRows.FillRectangle(brush, listView.RowsClientRect);
            brush.Dispose();

            // if they have a background image, then display it
            if (listView.BackgroundImage != null)
            {
                if (listView.BackgroundStretchToFit)
                {
                    graphicsRows.DrawImage(listView.BackgroundImage, listView.RowsInnerClientRect.X, listView.RowsInnerClientRect.Y, listView.RowsInnerClientRect.Width, listView.RowsInnerClientRect.Height);
                }
                else
                {
                    graphicsRows.DrawImage(listView.BackgroundImage, listView.RowsInnerClientRect.X, listView.RowsInnerClientRect.Y);
                }
            }

            // determine start item based on whether or not we have a vertical scrollbar present
            int nStartItem; // which item to start with in this visible pane
            if (vPanelScrollBar.Visible)
            {
                nStartItem = vPanelScrollBar.Value;
            }
            else
            {
                nStartItem = 0;
            }

            Rectangle rectRow = listView.RowsRect;
            rectRow.Height = listView.ItemHeight;

            /* Draw Rows */
            for (var item = 0; (item < listView.VisibleRowsCount + 1) && (item + nStartItem < listView.Items.Count); item++)
            {
                DrawRow(graphicsRows, rectRow, listView.Items[item + nStartItem], item + nStartItem, listView, hPanelScrollBar, _newLiveControls, _liveControls, checkBoxSize);
                rectRow.Y += listView.ItemHeight;
            }

            if (listView.GridLineStyle != GridLineStyle.None)
            {
                DrawGridLines(graphicsRows, vPanelScrollBar, hPanelScrollBar, listView);
            }

            // draw hot tracking column overlay
            if (listView.HotColumnTracking && (listView.HotColumnIndex != -1) && (listView.HotColumnIndex < listView.Columns.Count))
            {
                int nXCursor = -hPanelScrollBar.Value;
                for (int nColumnIndex = 0; nColumnIndex < listView.HotColumnIndex; nColumnIndex++)
                {
                    nXCursor += listView.Columns[nColumnIndex].Width;
                }

                using (Brush hotBrush = new SolidBrush(Color.FromArgb(75, listView.HotTrackingColor.R, listView.HotTrackingColor.G, listView.HotTrackingColor.B)))
                {
                    graphicsRows.FillRectangle(hotBrush, nXCursor, listView.RowsInnerClientRect.Y, listView.Columns[listView.HotColumnIndex].Width + 1, listView.RowsInnerClientRect.Height - 1);
                }
            }
        }

        /// <summary>Draw Sub Item (Cell) at location specified.</summary>
        /// <param name="graphicsSubItem">The graphics sub item.</param>
        /// <param name="rectSubItem">The rectangle sub item.</param>
        /// <param name="item">The item.</param>
        /// <param name="subItem">The sub item.</param>
        /// <param name="column">The column.</param>
        /// <param name="font">The font.</param>
        /// <param name="listView">The list View.</param>
        /// <param name="_newLiveControls">The _new Live Controls.</param>
        /// <param name="_liveControls">The _live Controls.</param>
        /// <param name="cellPaddingSize">The cell Padding Size.</param>
        /// <param name="checkBoxSize">The check Box Size.</param>
        public static void DrawSubItem(Graphics graphicsSubItem, Rectangle rectSubItem, VisualListViewItem item, VisualListViewSubItem subItem, int column, Font font, VisualListViewAdvanced listView, ArrayList _newLiveControls, ArrayList _liveControls, int cellPaddingSize, int checkBoxSize)
        {
            DebugTraceManager.WriteDebug("ListViewRenderer::DrawSubItem Name: " + subItem.Name, DebugTraceManager.DebugOutput.TraceListener);

            Rectangle _controlRectangle = new Rectangle(rectSubItem.X, rectSubItem.Y, rectSubItem.Width, rectSubItem.Height);

            if ((subItem.EmbeddedControl != null) && !subItem.ForceText)
            {
                Control _control = subItem.EmbeddedControl;

                if (_control.Parent != listView)
                {
                    _control.Parent = listView;
                }

                Rectangle _subItemRectangle = new Rectangle(
                    _controlRectangle.X,
                    _controlRectangle.Y + 1,
                    _controlRectangle.Width,
                    _controlRectangle.Height - 1);

                // Type _type = _control.GetType();
                PropertyInfo _propertyInfo = _control.GetType().GetProperty("PreferredHeight");
                if (_propertyInfo != null)
                {
                    var _preferredHeight = (int)_propertyInfo.GetValue(_control, null);

                    if ((_preferredHeight + (listView.CellPaddingSize * 2) > listView.ItemHeight) && listView.AutoHeight)
                    {
                        listView.ItemHeight = _preferredHeight + (listView.CellPaddingSize * 2);
                    }

                    _subItemRectangle.Y = _controlRectangle.Y + ((_controlRectangle.Height - _preferredHeight) / 2);
                }

                _newLiveControls.Add(_control);
                if (_liveControls.Contains(_control))
                {
                    _liveControls.Remove(_control);
                }

                if (_control.Bounds.ToString() != _subItemRectangle.ToString())
                {
                    _control.Bounds = _subItemRectangle;
                }

                if (_control.Visible != true)
                {
                    _control.Visible = true;
                }
            }
            else
            {
                // If the sub item color is not the same as the back color fo the control, AND the item is not selected, then color this sub item background
                if ((subItem.BackColor.ToArgb() != listView.BackColor.ToArgb()) && !item.Selected && (subItem.BackColor != Color.White))
                {
                    using (SolidBrush _backColorBrush = new SolidBrush(subItem.BackColor))
                    {
                        graphicsSubItem.FillRectangle(_backColorBrush, rectSubItem);
                    }
                }

                // Check if we need checkboxes in this column
                if (listView.Columns[column].CheckBoxes && subItem.CheckBox)
                {
                    rectSubItem = DrawCheckBox(graphicsSubItem, rectSubItem, subItem.Checked, checkBoxSize, listView);
                }

                // if there is an image, this routine will RETURN with exactly the space left for everything else after the image is drawn (or not drawn due to lack of space)
                if ((subItem.ImageIndex > -1) && (listView.ImageList != null) && (subItem.ImageIndex < listView.ImageList.Images.Count))
                {
                    rectSubItem = DrawCellGraphic(graphicsSubItem, rectSubItem, listView.ImageList.Images[subItem.ImageIndex], subItem.ImageAlignment, cellPaddingSize, listView);
                }

                // deal with text color in a box on whether it is selected or not
                Color textColor;
                if (item.Selected && listView.Selectable)
                {
                    textColor = listView.SelectedTextColor;
                }
                else
                {
                    textColor = listView.ForeColor;
                    if (item.ForeColor.ToArgb() != listView.ForeColor.ToArgb())
                    {
                        textColor = item.ForeColor;
                    }
                    else if (subItem.ForeColor.ToArgb() != listView.ForeColor.ToArgb())
                    {
                        textColor = subItem.ForeColor;
                    }
                }

                DrawCellText(graphicsSubItem, rectSubItem, subItem.Text, font, listView.Columns[column].TextAlignment, textColor, item.Selected, listView);
                subItem.LastCellRect = rectSubItem; // important to ONLY catch the area where the text is drawn
            }
        }

        #endregion
    }
}