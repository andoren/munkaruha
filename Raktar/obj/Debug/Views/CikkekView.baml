   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5   	       Raktar.Views.CikkekView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Raktar.Views     5   	   -   5          � WindowStyle$
  None=�5       � AllowsTransparency . 
������  � Title$ Cikk hozzáadása��5   	   $	��197��6!   $	��379��6.    � Topmost .  � WindowStartupLocation$ CenterOwner=�6I   .��5      ��  �� Padding$ 0q�6   $��0q�6   
����������#2868b0$��4q�6M    �� CornerRadius$ 4��6a   ._�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� $��Center=�6   $��Center=�63   $��30(�6P   Cikk kiválasztása6r   �� 5      -   5         ��Name$ Cikkek��5   �   	 �� 
IsEditable	 . $��10q�6)   $��Center=�65   $
��Left=�6W   $��20(�6y   $��1��6�   
 �� DisplayMemberPath$
 NameForCikk��6�    �� SelectedItem 6�   �� *	Munkaruha+6�   �� 5      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��Center=�6Z   .+�5      �� -   5         ��Name$
 Save��5      $��0,0,20,0q�6'   $	��100��69   $��40��6E   .��6Q   	Mentés5      �� 5      -   5        $
 Exit��5      $	��100��6(   $��40��64   .��6@   Mégse5      5      5      5       5!      