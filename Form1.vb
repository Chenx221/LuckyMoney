Public Class Form1
    '变量声明
    Dim M As Integer : Dim Num As Integer
    Dim Temp As Double : Dim f As Double 'Temp存储随机值*10的整数 F存储金额
    Dim zd As Double '最大&最小
    Dim temp2 As Double '比较最大值
    Dim daNum As Integer '存放哪两个人拿到最大金额


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Add("程序加载完毕")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        M = Val(TextBox1.Text)   '总金额
        Num = Val(TextBox2.Text)    '总人数

        For i = 1 To Num - 1 '剩下一人拿走最后的余额
            Temp = Int((Rnd() + 1) * 4) '
            f = FormatNumber(M / Temp, 3) '越早抢越有可能拿到大红包

            If f >= temp2 Then '最大值最小值判断
                zd = f
                daNum = i
            End If

            Do While M = f '这是为了避免{如果Temp=1 →F=M →一个人把钱全拿走了}
                Temp = Int((Rnd() + 1) * 4)
                f = FormatNumber(M / Temp, 3)
            Loop
            ListBox1.Items.Add("恭喜第" + Str(i) + "名获得" + Str(f) + "元")
            M = M - f

        Next i
        ListBox1.Items.Add("恭喜第" + Str(Num) + "名获得" + Str(M) + "元")

        If M >= zd Then
            zd = M
            daNum = Num
        End If

        ListBox1.Items.Add("第" + Str(daNum) + "名是幸运王，金额为" + Str(zd) + "元")
        'Fin
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = "" : TextBox2.Text = "" : ListBox1.Items.Clear()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://chenx221.xyz/blog")
    End Sub
End Class
