Imports System.Data.SqlClient
Imports System.Data
Public Class Form3


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim con As New SqlConnection("Server=192.168.27.30;DATABASE=farmacia; User id= user; Password=pquinde")
        con.Open()
        Dim sql As String = "select * from cliente where cedula = @ced"
        Dim cmd As New SqlCommand(sql, con)

        cmd.Parameters.AddWithValue("@ced", CInt(txtcedula.Text))

        Dim read As SqlDataReader = cmd.ExecuteReader()

        If (read.Read) Then
            txtcedula.Text = Convert.ToString(read("cedula"))
            txtnombre.Text = Convert.ToString(read("nombre"))
            txtapellido.Text = Convert.ToString(read("apellido"))
            txtcorreo.Text = Convert.ToString(read("correo"))
            txtdireccion.Text = Convert.ToString(read("direccion"))
        End If
        con.Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection("Server=192.168.27.30;DATABASE=farmacia; User id= user; Password=pquinde")
        Dim sa As New SqlDataAdapter("select * from cliente", con)
        Dim ds As New DataSet
        sa.Fill(ds, "cliente")
        DataGridView1.DataSource = ds.Tables("cliente")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection("Server=192.168.27.30;DATABASE=farmacia; User id= user; Password=pquinde")
        Dim sa As New SqlCommand("update cliente set nombre = @nom, apellido = @ape, correo = @cor, direccion = @dir where cedula = @ced ", con)

        sa.Parameters.Add("@ced ", SqlDbType.VarChar).Value = txtcedula.Text
        sa.Parameters.Add("@nom ", SqlDbType.VarChar).Value = txtnombre.Text
        sa.Parameters.Add("@ape", SqlDbType.VarChar).Value = txtapellido.Text
        sa.Parameters.Add("@cor", SqlDbType.VarChar).Value = txtcorreo.Text
        sa.Parameters.Add("@dir", SqlDbType.VarChar).Value = txtdireccion.Text

        con.Open()
        If sa.ExecuteNonQuery() = 1 Then
            MsgBox("Datos actualizados", MsgBoxStyle.Information)
        Else
            MsgBox("Datos no actualizados", MsgBoxStyle.Critical)
        End If
        con.Close()
        Dim cmd As New SqlDataAdapter("select * from cliente", con)
        Dim ds As New DataSet
        cmd.Fill(ds, "cliente")
        DataGridView1.DataSource = ds.Tables("cliente")
        txtcedula.Text = ""
        txtnombre.Text = ""
        txtapellido.Text = ""
        txtcorreo.Text = ""
        txtdireccion.Text = ""
    End Sub
End Class