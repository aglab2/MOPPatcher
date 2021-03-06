﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOPPatcher
{
    public partial class PatcherForm : Form
    {
        WritePatch shrinkPlatformsReappear;
        WritePatch sandblocksReappear;
        WritePatch switchblocksLedgegrabbable;

        WritePatch switchblocksNotSlippery;
        WritePatch switchNotSlippery;
        WritePatch flipswapNotSlippery;

        WritePatch flipswapSpeed1;
        WritePatch flipswapSpeed2;
        WritePatch flipswapSpeed4;
        WritePatch flipswapSpeed8;
        WritePatch flipswapSpeed16;

        WritePatch mopcrashcherryPickPatch;
        ReplacePatch mopcrashPatch;

        ROM rom;

        public PatcherForm()
        {
            InitializeComponent();

            shrinkPlatformsReappear = new WritePatch();
            shrinkPlatformsReappear.AddRegion(0x65850, new byte[] { 0x10, 0x00, 0x00, 0x34 });
            shrinkPlatformsReappear.AddRegion(0x658AC, new byte[] { 0x10, 0x00, 0x00, 0x0F });
            shrinkPlatformsReappear.AddRegion(0x658EC, new byte[] { 0x29, 0x01, 0x01, 0x00, 0x14, 0x20, 0xFF, 0xFB,
                0x00, 0x00, 0x00, 0x00, 0x24, 0x08, 0x00, 0x01, 0xAC, 0x68, 0x01, 0x80, 0x3C, 0x01, 0x3F, 0x80,
                0x0C, 0x0A, 0x7D, 0x0C, 0x44, 0x81, 0x60, 0x00, 0x10, 0x00, 0xFF, 0xF4, 0xAC, 0x60, 0x01, 0x4C,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x15, 0x00, 0xFF, 0xD1, 0x8C, 0x79, 0x01, 0x80, 0x17, 0x20, 0xFF, 0xCF, 0x00, 0x00, 0x00, 0x00,
                0x10, 0x00, 0xFF, 0xC8, 0x00, 0x00, 0x00, 0x00 });

            sandblocksReappear = new WritePatch();
            sandblocksReappear.AddRegion(0x651C0, new byte[] { 0x08, 0x0B, 0xBD, 0xD8 });
            sandblocksReappear.AddRegion(0x65230, new byte[] { 0x08, 0x0B, 0xBD, 0xBC });
            sandblocksReappear.AddRegion(0xAA6F0, new byte[] { 0x00, 0x88, 0x08, 0x2A, 0x14, 0x20, 0x00, 0x03,
                0x00, 0x00, 0x00, 0x00, 0x08, 0x0A, 0xA8, 0x91, 0x00, 0x00, 0x00, 0x00, 0x24, 0x42, 0x00, 0x01,
                0xAC, 0x62, 0x01, 0x80, 0x8C, 0x62, 0x01, 0x7C, 0xA4, 0x40, 0x00, 0x74, 0x29, 0x01, 0x01, 0x40,
                0x14, 0x20, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0xAC, 0x60, 0x01, 0x80, 0x3C, 0x08, 0x3F, 0x80,
                0xAC, 0x68, 0x00, 0x30, 0x3C, 0x08, 0x43, 0x98, 0x25, 0x08, 0x49, 0xFC, 0x44, 0x88, 0x00, 0x00,
                0x8C, 0x68, 0x00, 0xA4, 0x44, 0x88, 0x10, 0x00, 0x46, 0x00, 0x10, 0x01, 0xE4, 0x60, 0x00, 0xA4,
                0xAC, 0x60, 0x01, 0x4C, 0x08, 0x0A, 0xA8, 0x9D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3C, 0x03, 0x80, 0x36, 0x8C, 0x63, 0x11, 0x60,
                0x8C, 0x68, 0x01, 0x54, 0x8C, 0x69, 0x01, 0x80, 0x15, 0x20, 0xFF, 0xE8, 0x00, 0x00, 0x00, 0x00,
                0x0C, 0x0A, 0x8F, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x08, 0x0A, 0xA8, 0x72, 0x00, 0x00, 0x00, 0x00 });

            switchblocksLedgegrabbable = new WritePatch();
            switchblocksLedgegrabbable.AddRegion(0x7D305C, new byte[] { 0x00, 0x96, 0x00, 0x96, 0x00, 0x96, 0xFF, 0x76,
                0xFF, 0x76, 0x00, 0x96, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0x00, 0x96,
                0x00, 0x96, 0x00, 0x96, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0x00, 0x96, 0x00, 0x96, 0x00, 0x96,
                0xFF, 0x76, 0xFF, 0x76, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0x00, 0x96, 0xFF, 0x76, 0xFF, 0x76,
                0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76,
                0x00, 0x96, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76,
                0x00, 0x96, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0x00, 0x96,
                0xFF, 0x76, 0xFF, 0x76, 0x00, 0x96, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0x00, 0x96, 0x00, 0x96,
                0xFF, 0x76, 0xFF, 0x76, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96, 0x00, 0x96, 0xFF, 0x76, 0x00, 0x96,
                0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0x80, 0x00,
                0xFF, 0x76, 0xFF, 0x76, 0x80, 0x00, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76, 0xFF, 0x76 });
            //0x00, 0x15 });

            switchblocksNotSlippery = new WritePatch();
            switchblocksNotSlippery.AddRegion(0x7D3105, new byte[] { 0x15 });
            
            switchNotSlippery = new WritePatch();
            switchNotSlippery.AddRegion(0x7D742B, new byte[] { 0x15 });

            flipswapNotSlippery = new WritePatch();
            flipswapNotSlippery.AddRegion(0x7D9E65, new byte[] { 0x15 });

            flipswapSpeed1 = new WritePatch();
            flipswapSpeed1.AddRegion(0x68E6A, new byte[] { 0x04, 0x00 });
            flipswapSpeed1.AddRegion(0x68E76, new byte[] { 0xFC, 0x00 });
            flipswapSpeed1.AddRegion(0x68E9B, new byte[] { 0x1F });

            flipswapSpeed2 = new WritePatch();
            flipswapSpeed2.AddRegion(0x68E6A, new byte[] { 0x08, 0x00 });
            flipswapSpeed2.AddRegion(0x68E76, new byte[] { 0xF8, 0x00 });
            flipswapSpeed2.AddRegion(0x68E9B, new byte[] { 0x0F });

            flipswapSpeed4 = new WritePatch();
            flipswapSpeed4.AddRegion(0x68E6A, new byte[] { 0x10, 0x00 });
            flipswapSpeed4.AddRegion(0x68E76, new byte[] { 0xF0, 0x00 });
            flipswapSpeed4.AddRegion(0x68E9B, new byte[] { 0x07 });

            flipswapSpeed8 = new WritePatch();
            flipswapSpeed8.AddRegion(0x68E6A, new byte[] { 0x20, 0x00 });
            flipswapSpeed8.AddRegion(0x68E76, new byte[] { 0xE0, 0x00 });
            flipswapSpeed8.AddRegion(0x68E9B, new byte[] { 0x03 });

            flipswapSpeed16 = new WritePatch();
            flipswapSpeed16.AddRegion(0x68E6A, new byte[] { 0x40, 0x00 });
            flipswapSpeed16.AddRegion(0x68E76, new byte[] { 0xC0, 0x00 });
            flipswapSpeed16.AddRegion(0x68E9B, new byte[] { 0x01 });
            
            mopcrashPatch = new ReplacePatch(4, 0x0, 0x1200000);
            mopcrashPatch.AddPattern(new byte[] { 0x21, 0x08, 0x00, 0x7B }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashPatch.AddPattern(new byte[] { 0x22, 0x08, 0x00, 0x7B }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            mopcrashPatch.AddPattern(new byte[] { 0x21, 0x08, 0x00, 0x2F }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashPatch.AddPattern(new byte[] { 0x22, 0x08, 0x00, 0x2F }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            mopcrashPatch.AddPattern(new byte[] { 0x21, 0x08, 0x00, 0x2C }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashPatch.AddPattern(new byte[] { 0x22, 0x08, 0x00, 0x2C }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            mopcrashPatch.AddPattern(new byte[] { 0x21, 0x08, 0x00, 0x2D }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashPatch.AddPattern(new byte[] { 0x22, 0x08, 0x00, 0x2D }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            mopcrashPatch.AddPattern(new byte[] { 0x21, 0x08, 0x00, 0x2E }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashPatch.AddPattern(new byte[] { 0x22, 0x08, 0x00, 0x2E }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            mopcrashPatch.AddPattern(new byte[] { 0x21, 0x08, 0x00, 0x27 }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashPatch.AddPattern(new byte[] { 0x22, 0x08, 0x00, 0x27 }, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            mopcrashcherryPickPatch = new WritePatch();
            mopcrashcherryPickPatch.AddRegion(0x49E100, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            mopcrashcherryPickPatch.AddRegion(0x4EB5FC, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashcherryPickPatch.AddRegion(0x395ED4, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashcherryPickPatch.AddRegion(0x3CFC44, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
            mopcrashcherryPickPatch.AddRegion(0x4AF788, new byte[] { 0x10, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
        }

        private void loadRomButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                // Set filter options and filter index.
                openFileDialog1.Filter = "Text Files (.z64)|*.z64|All Files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;

                openFileDialog1.Multiselect = true;

                // Call the ShowDialog method to show the dialog box.
                DialogResult userClickedOK = openFileDialog1.ShowDialog();

                // Process input if the user clicked OK.
                if (userClickedOK == DialogResult.OK)
                {
                    rom = new ROM(openFileDialog1.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load rom!", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void patchButton_Click(object sender, EventArgs e)
        {
            if (rom == null)
            {
                MessageBox.Show("No ROM loaded!", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (shrinkReappearCheckBox.Checked)
                shrinkPlatformsReappear.Apply(rom);

            if (sandblocksReappearCheckBox.Checked)
                sandblocksReappear.Apply(rom);

            if (switchblocksLedgegrabableCheckBox.Checked)
                switchblocksLedgegrabbable.Apply(rom);

            if (switchblocksNotSlipperyCheckbox.Checked)
                switchblocksNotSlippery.Apply(rom);

            if (switchNotSlipperyCheckbox.Checked)
                switchNotSlippery.Apply(rom);

            if (flipswapNotSlipperyCheckbox.Checked)
                flipswapNotSlippery.Apply(rom);

            if (flipswapRadioButton1.Checked)
                flipswapSpeed1.Apply(rom);

            if (flipswapRadioButton2.Checked)
                flipswapSpeed2.Apply(rom);

            if (flipswapRadioButton4.Checked)
                flipswapSpeed4.Apply(rom);

            if (flipswapRadioButton8.Checked)
                flipswapSpeed8.Apply(rom);

            if (flipswapRadioButton16.Checked)
                flipswapSpeed16.Apply(rom);

            if (crashesCheckBox.Checked)
            {
                mopcrashcherryPickPatch.Apply(rom);
                mopcrashPatch.Apply(rom);
            }

            try
            {
                rom.WriteData();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to writeback data to ROM!", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Process chksumProcess = Process.Start("chksum64.exe", rom.name);
                chksumProcess.WaitForExit(1000);
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to recalculate chksum!", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Your ROM was patched!", "Patcher", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
