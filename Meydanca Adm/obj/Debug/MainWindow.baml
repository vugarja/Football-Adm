   M S B A M L   `   `   `  ����G  CMeydanca Adm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Meydanca_AdmMeydanca_Adm  5   	       Meydanca_Adm.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Meydanca_Adm     5   	     � Title$  Futbol Meydançası��5   	   $	��600��6#   $
��1000��60   $��Malgun Gothic)�6=    � WindowStartupLocation$ CenterOwner=�6X    � 
ResizeMode$ NoResize=�6|   .��5	      � $��	0,0,0,0.5q�6   .+�5
   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ dtpDate��5
      $
��Left=�6'   $��
50,166,0,0q�6B   $	��Top=�6V   $��27��6n   $	��190��6z      FirstDayOfWeek$ Monday=�6�      SelectedDateFormat$ Short=�6�   6�   �� 5   
   -   5         ��Name$ lblDate��5      $��Tarix Seçin��6!   $
��Left=�67   $��
50,139,0,0q�6R   $	��Top=�6f   $��14(�6~   �� 5   
   -   5        $ 
lblWelcome��5      $3��-Futbol Meydança Sisteminə Xoş Gəlmisiniz!��6$   $
��Left=�6X   $��38.5,37,0,0q�6s   $	��Top=�6�   $��20(�6�   $
��Bold"�6�   
�������
���  ��$��1��6�   �� 5   
   -   5        $ lblRegister��5      $��	Qeydiyyat��6%   $
��Left=�69   $��	50,91,0,0q�6T   $	��Top=�6g   $
��Bold"�6   $��16(�6�   �� 5   
   -   5        $ 
lblStadium��5      $��Meydança seçin��6$   $
��Left=�6=   $y�Visible=�6X   $��
50,225,0,0q�6m   $	��Top=�6�   $��14(�6�   �� 5   
   -   5         ��Name$ cmbStadiums��5      $y�Visible=�6(   $
��Left=�6=   $��
50,254,0,0q�6X   $	��Top=�6l   $	��190��6�   6�   �� 5   
   -   5        $ CmbHours��5      $
��Left=�6%   $��272,166,0,0q�6@   $	��Top=�6U   $	��128��6m   $y�Visible=�6y   6�   �� 5   
   -   5        $ lblUser��5      $��İstifadəçi seçin��6!   $
��Left=�6<   $��
49,300,0,0q�6W   $	��Top=�6k   $��14(�6�   $y�Visible=�6�   �� 5   
   -	   5        $ CmbUsers��5      $
��Left=�6%   $��
53,329,0,0q�6@   $	��Top=�6T   $	��190��6l   $y�Visible=�6x   6�   �� 5   
   -
   5         ��Name$ 
btnStadium��5      $��Meydança Yarat��6%   $
��Left=�6>   $��274,252,0,0q�6Y   $	��Top=�6n   $	��122��6�   $��24��6�   $y�Visible=�6�   6�   �� 5   
   -   5        $ btnUser��5      $��İstifadəçi Yarat��6"   $
��Left=�6=   $��273,326,0,0q�6X   $	��Top=�6m   $	��122��6�   $��24��6�   	 J� RenderTransformOrigin$	 
-0.107,0.5&�6�   $y�Visible=�6�   6�   �� 5   
   -   5        $ btnComplete��5      $��Qeydiyyatı tamamla��6&   $
��Left=�6C   $��
88,397,0,0q�6^   $	��Top=�6r   $	��217��6�   $��49��6�   $��2��6�   $y�Visible=�6�   6�   �� 5   
   -   5        $ lblHours��5      $��Saat Seçin��6"   $
��Left=�67   $��272,137,0,0q�6R   $	��Top=�6g   $��14(�6   $	 0.5,0.5&�6�   $y�Visible=�6�   5      5      5      