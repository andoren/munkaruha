   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5   	   '    !Raktar.Views.AddAndModifyCikkView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Raktar.Views     5   	   ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5   	   -   5          � WindowStyle$
  None=�5	   	    � AllowsTransparency . 
������  � Title$
 Cikk��5   	   $	��220��6   $	��454��6#    � WindowStartupLocation$ CenterOwner=�6/   $��Roboto)�5   	   .��5      ��  �� Padding$ 0q�6   $��0q�6   
����������#2868b0$��4q�6M    �� CornerRadius$ 4��6a   ._�5      �� $��Stretch=�6   .+�5   
   �� $��35(�6   $��5q�6"   $��Center=�6-   Új cikk hozzáadása6^   � 5   
   $��5q�6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5      �� $��Center=�6   $��20(�63   
Cikk neve:6M   �� 5      -   5         ��Name$ NewName��5   W   $��1��6   $��5,0,0,0q�6*   $��Center=�6;   $��20(�6i   6y   5      � 5   
   $��5q�6    5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5       �� $��Center=�6   $��20(�67   Mértékegysége:6V   �� 5!      -   5        $ Mertekegyseg��5!   R   $��1��6   $��5,0,0,0q�6&   $��Center=�67   $��20(�6i   6y   5"      � 5#   
   $��5q�6    5$      �� 5%      $
��auto �6#   �� 5&      $��* �6#   .+�5(      �� $��Center=�6   $��20(�67   Cikkcsoport kiválasztása:6`   �� 5)      -   5         ��Name$ Groups��5)   U   $��1��6E   	 �� DisplayMemberPath$
	 Name��6�   $��20(�6�   $��5,0,0,0q�6�   {�6   �� *OsztalyBoxIsEnabled+
 �� SelectedItem
 6e   �� *Group+6�   5*      � 5+   
   $��5q�6    5,      �� 5-      $��* �6#   �� 5.      $��* �6#   .+�50      �� -   5         ��Name$ 
SaveAction��50      $��0��6*      	AddButton#��[  6;   .��51      �� -   5         ��Name$ 
ButtonText��51       66   6B   �� 52      -   5        $ CloseWindow��52        DeleteButton#��[ 6*   $��1��6P   .��6a   	Kilépés6j   53      54      55      56      