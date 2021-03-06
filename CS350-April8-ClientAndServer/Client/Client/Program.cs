﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using NUnit.Framework;

// CS 350 Spring 2014 Software Design
// Team 3 Adam Piersa, Erik Johnson, Marisa Briggs
// reference: http://www.codeproject.com/Articles/1415/Introduction-to-TCP-client-server-in-C
// client software
public class Client
{
    
    public static void Main(string[] argv)
    {

        const int DOMAIN_NAME_ARG = 0;
        const int PORT_NUMBER_ARG = 1;
      
           try
           {
            TcpClient Tcpclnt = new TcpClient();
            Console.WriteLine("Connecting.....");
            int portNumber = Convert.ToInt32(argv[PORT_NUMBER_ARG]);
            connect(Tcpclnt,argv[DOMAIN_NAME_ARG], portNumber);
            //while (Console.ReadLine() != "Close")
            //{
             //   sendMessage(Tcpclnt);
            String sendString;
            Stream serverSendStream = Tcpclnt.GetStream();
            //String sendString = "Hellllllllloooooooooooooooooooooooooooooooooooooooooooooooo";
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] bytesInSend;
            //Console.WriteLine("Transmitting.....");

            
            // send length then string to read to length+1
               while(true)
               {
                 sendString = sendMessage(Tcpclnt);
                 const string EXIT_STRING = "exit";
                 //sendString = Console.ReadLine();
                 //  //MIGHT NEEEEDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDd
                 ////sendString += "\n\r";
                 //bytesInSend= asen.GetBytes(sendString);
                 //serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);
                 //serverSendStream.Flush();
                 if (sendString.ToLower() == EXIT_STRING)
                     break;
               }
             //   receiveMessage(Tcpclnt);

                ////
     

           //byte[] bytesToRead = new byte[100];
                //int numberOfBytesRead = serverSendStream.Read(bytesToRead, 0, bytesToRead.Length);

                //for (int i = 0; i < numberOfBytesRead; i++)
                //    Console.Write(Convert.ToChar(bytesToRead[i]));
         //   }
               Tcpclnt.Close();
        }

        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }

    }


    public  static bool connect(TcpClient tcpclnt, string iPAddress, int portNumber)
    {
        IPAddress ipAdd = IPAddress.Any;
 
        //TcpClient tcpclnt = new TcpClient();
        
        tcpclnt.Connect(iPAddress, portNumber);
        
        
        bool connectedStatus = tcpclnt.Connected;
        
        return connectedStatus;
    }


    public static string sendMessage(TcpClient tcpclnt)
    {
        String sendString = Console.ReadLine();
        Stream serverSendStream = tcpclnt.GetStream();
        //String sendString = "Hellllllllloooooooooooooooooooooooooooooooooooooooooooooooo";
        ASCIIEncoding asen = new ASCIIEncoding();
        byte[] bytesInSend = asen.GetBytes(sendString);
        //Console.WriteLine("Transmitting.....");
        serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);
        serverSendStream.Flush();
        int nBytes = bytesInSend.Length;
        return sendString;
        
    }

    public static int testSendMessage(TcpClient tcpclnt)
    {
        //String sendString = Console.ReadLine();
        Stream serverSendStream = tcpclnt.GetStream();
        String sendString = "Testing client receive message from server";
        ASCIIEncoding asen = new ASCIIEncoding();
        byte[] bytesInSend = asen.GetBytes(sendString);
        //Console.WriteLine("Transmitting.....");


        // send length then string to read to length+1
        serverSendStream.Write(bytesInSend, 0, bytesInSend.Length);
        int nBytes = bytesInSend.Length;
        return nBytes;
    }

    public static int receiveMessage(TcpClient tcpclnt)
    {
        const int MAX_CHARS = 1500;
        Stream serverStream = tcpclnt.GetStream();

        Byte[] buffer = new Byte[MAX_CHARS];

        Int32 bytes = serverStream.Read(buffer, 0, buffer.Length);
        String responceMessage = System.Text.Encoding.ASCII.GetString(buffer, 0, bytes);
        Console.WriteLine("Received: ", responceMessage);
        Console.Write(responceMessage);
        return bytes;
    }

}
