   M S B A M L   `   `   `  ����G  CJagoanFisika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFPageSwitch.ViewsWPFPageSwitch.Views  5      $    WPFPageSwitch.Views.ImportCars   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPFPageSwitch.Views     5      $	��600��5   7   .��5	      � ��5
   
   �� 5        �� EndPoint$  0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 0.611Q�6-   5       � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��440 �6   �� 5      $��80 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��0��6   $��	30,20,0,0q�6(   $#��Aktualnie sprowadzane pojazdy��6;   $��28(�6`   $��Dubai)�6n   
�������6�   �� 5      $��1��6   $��	0,20,30,0q�6(   $��Janusz��6;   $��36(�6I   $��Magneto)�6W   
�������$��Right=�6   5      � 5   
   $��1��6   .+�5      �� -   5        $��carsDuringImport��5   #   $��10q�6    �� View 5      �� 5       .P�5!      �� $��Pojazd��6)    �� Width$	 300��69    �� DisplayMemberBinding 6E   �� *Make+�� 5"      $��Pozostaly czas��6)   $	 150��6A    6M   �� *Time+�� 5#      $��
Anulowanie��6)   $	 150��6=   -   5        testowe��	 �� CellTemplate	 5$      �� 5%   "   .R�5&   &   �� -   5        $��Anuluj��5&   -   
���  ��$��Center=�6�   ��6j   �� *Id+6�   5'   #   5)      5*      5,      5-      �� 5.   
   -   5        $��
backButton��5.   /   $��2��6   $��Powrot��6   $��Right=�6V   
�������$	��100��6�   $��30��6�   $��
0,0,150,50q�6�   5/      50      