Imports System.Data.SqlClient
Imports System.Data

Public Class Form2


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub insertarcliente()
        Dim ced As String
        Dim nom As String
        Dim ape As String
        Dim cor As String
        Dim dir As String

      


        Dim con As New SqlConnection("Server=192.168.27.30;DATABASE=farmacia; User id= user; Password=pquinde")

        Try
            con.Open()
            ced = txtcedula.Text.ToString
            nom = txtnombre.Text
            ape = txtapellido.Text
            cor = txtcorreo.Text
            dir = txtdireccion.Text
            Dim sqlquery As String = "insert into cliente (cedula,nombre,apellido,correo,direccion) values('" & ced & "','" & nom & "','" & ape & "','" & cor & "','" & dir & "')"
            Dim coman As SqlCommand
            coman = New SqlCommand(sqlquery, con)
            coman.ExecuteNonQuery()
            MsgBox("Datos ingresados", MsgBoxStyle.Information)
            txtcedula.Text = ""
            txtnombre.Text = ""
            txtapellido.Text = ""
            txtcorreo.Text = ""
            txtdireccion.Text = ""
        Catch ex As Exception
            MsgBox("error al insertar", MsgBoxStyle.Critical)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        insertarcliente()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub txtcedula_TextChanged(sender As Object, e As EventArgs) Handles txtcedula.TextChanged

    End Sub

    Private Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged

    End Sub

    Private Sub txtapellido_TextChanged(sender As Object, e As EventArgs) Handles txtapellido.TextChanged

    End Sub

    Private Sub txtcorreo_TextChanged(sender As Object, e As EventArgs) Handles txtcorreo.TextChanged

    End Sub

    Private Sub txtdireccion_TextChanged(sender As Object, e As EventArgs) Handles txtdireccion.TextChanged

    End Sub
End Class