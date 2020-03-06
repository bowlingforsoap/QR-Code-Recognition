using Microsoft.MixedReality.QR;
using QRTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GettingNewQRCodeExampleScript : MonoBehaviour
{
    public QRCodesManager qrCodesManager;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        qrCodesManager.QRCodeAdded += LogQRCode;
        qrCodesManager.QRCodeAdded += AppendText;
    }

    private void AppendText(object sender, QRCodeEventArgs<Microsoft.MixedReality.QR.QRCode> e)
    {
        if (e != null)
        {
            var qrCode = e.Data;
            text.text += $"\nNew QR code found: id = {qrCode?.Id}, text = {GetQRCodeText(qrCode)}";
        }
    }

    private void LogQRCode(object sender, QRCodeEventArgs<Microsoft.MixedReality.QR.QRCode> e)
    {
        if (e != null)
        {
            var qrCode = e.Data;
            Debug.Log($"New QR code found: id = {qrCode?.Id}, text = {GetQRCodeText(qrCode)}");
        }
    }

    private string GetQRCodeText(Microsoft.MixedReality.QR.QRCode qrCode)
    {
        return qrCode?.Data;
    }
}
