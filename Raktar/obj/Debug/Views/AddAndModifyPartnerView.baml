   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5   	   *    $Raktar.Views.AddAndModifyPartnerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Raktar.Views     5   	   -   5          � WindowStyle$
  None=�5   	    � AllowsTransparency . 
������  � Title$ Partner��5   	   $	��170��6   $	��450��6&    � WindowStartupLocation$ CenterOwner=�62   .��5      ��  �� Padding$ 0q�6   
����������#2868b0$��4q�6B    �� CornerRadius$ 4��6V   ._�5      �� $��10q�6   .+�5      �� $��36(�6   $��Center=�6&   Új partner hozzáadása6[   � 5   
   $��5q�6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      �� $��Center=�6   $��20(�63   Megnevezés:6O   �� 5      -   5         ��Name$ NewName��5   l   $��10,5,5,5q�6   $��20(�6,   $��Center=�6:   $��1��6\   6�   5      � 5   
   -   5         �Name$	 Cim��5      	 � RowDefinitions	 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5       $
��auto �6    �� 5!      $
��auto �6    �� 5"      $
��auto �6     5$      �� 5%      $
��auto �6#   �� 5&      $��* �6#   5)      � 5+   
   $��5q�6    5,      �� 5-      $��* �6#   �� 5.      $��* �6#   .+�51      �� -   5        
 ��Name$
 
SaveAction��51         	AddButton#��[  6)   $��0��6L   .��6]   Hozzáadás6h   �� 52      -   5        $
 CloseWindow��52        DeleteButton#��[ 6*   $��1��6P   .��6c   	Kilépés6l   54      57      58      59      