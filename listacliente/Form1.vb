Imports System.Data.SqlClient
Imports System.Data

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarCliente()
        tcliente.Text = DataGridView1.Rows.Count - 1


    End Sub
    Sub listarCliente()
        Dim con As New SqlConnection("Server=192.168.100.53;DATABASE=farmacia; User id= user; Password=pquinde")
        Dim sa As New SqlDataAdapter("select * from cliente", con)
        Dim ds As New DataSet
        sa.Fill(ds, "cliente")
        DataGridView1.DataSource = ds.Tables("cliente")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection("Server=192.168.100.53;DATABASE=farmacia; User id= user; Password=pquinde")
        Dim sa As New SqlDataAdapter("select * from cliente", con)
        Dim ds As New DataSet
        sa.Fill(ds, "cliente")
        DataGridView1.DataSource = ds.Tables("cliente")
        tcliente.Text = DataGridView1.Rows.Count - 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()

    End Sub
End Class
