   M S B A M L   `   `   `  ����G  CJagoanFisika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFPageSwitch.ViewsWPFPageSwitch.Views  5      '    !WPFPageSwitch.Views.BuyerDataForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:WPFPageSwitch.Views     5      .��5	      � ��5
   
   �� 5        �� EndPoint$  0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 0.611Q�6-   5       � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��40 �6   �� 5      $��20 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $	��140 �6   �� 5      $��80 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      �� 5       .+�5"      �� $��0��6   $��	30,20,0,0q�6(   $��Dane kupujacego��6;   $��28(�6R   $��Dubai)�6`   
�������6s   �� 5#      $��1��6   $��	0,20,30,0q�6(   $��Janusz��6;   $��36(�6I   $��Magneto)�6W   
�������$��Right=�6   5$      � 5%   
   $��1��6   .+�5&      �� $��Wprowadz dane do umowy��6   $��Center=�66   $��Center=�6S   $��20(�6n   
�������6|   5'      � 5(   
   $��3��6    5)      �� 5*      �� 5+      .+�5-      �� $��0��6   $��Imie/Nazwa:��6(   $��Center=�6;   $��Center=�6X   $��18(�6s   
���  ��6�   �� 5.      -   5        $��
buyer_name��5.      $��1��6(   $	��200��68   $��20��6D   $��Center=�6P   $��Center=�6m   5/      � 50   
   $��4��6    51      �� 52      �� 53      .+�55      �� $��0��6   $��	Nazwisko:��6(   $��Center=�69   $��Center=�6V   $��18(�6q   
���  ��6   �� 56      -   5        $��buyer_surname��56      $��1��6+   $	��200��6;   $��20��6G   $��Center=�6S   $��Center=�6p   57      � 58   
   $��5��6    59      �� 5:      �� 5;      .+�5=      �� $��0��6   $��Seria i numer dokumentu:��6(   $��Center=�6H   $��Center=�6e   $��18(�6�   
���  ��6�   �� 5>      -   5        $��buyer_idnumber��5>      $��1��6,   $	��200��6<   $��20��6H   $��Center=�6T   $��Center=�6q   5?      � 5@   
   $��6��6    5A      �� 5B      �� 5C      .+�5E      �� $��0��6   $��Adres:��6(   $��Center=�66   $��Center=�6S   $��18(�6n   
���  ��6|   �� 5F      -   5        $��buyer_address��5F      $��1��6+   $	��200��6;   $��20��6G   $��Center=�6S   $��Center=�6p   5G      � 5H   
   $��7��6    5I      �� 5J      �� 5K      .+�5M      �� $��0��6   $��Kod pocztowy:��6(   $��Center=�6=   $��Center=�6Z   $��18(�6u   
���  ��6�   �� 5N      -   5        $��buyer_postalcode��5N      $��1��6.   $	��200��6>   $��20��6J   $��Center=�6V   $��Center=�6s   5O      � 5P   
   $��8��6    5Q      �� 5R      �� 5S      .+�5U      �� $��0��6   $��Miasto:��6(   $��Center=�67   $��Center=�6T   $��18(�6o   
���  ��6}   �� 5V      -   5        $��buyer_postalcity��5V      $��1��6.   $	��200��6>   $��20��6J   $��Center=�6V   $��Center=�6s   5W      �� 5X   
   -   5        $��
backButton��5X   0   $��10��6   $��Powrot��6   $��Right=�6W   
�������$	��100��6�   $��30��6�   $��
0,0,150,50q�6�   �� 5Y   
   -   5        $��
sellButton��5Y   2   $��10��6   $��Sprzedaj��6   $
��Left=�6X   
�������$	��100��6�   $��30��6�   $��
150,0,0,50q�6�   �� 5Z   
   -	   5        $��printButton��5Z   6   $��10��6   $��Drukuj umowe��6   $
��Left=�6^   
�������$	��100��6�   $��30��6�   $��
270,0,0,50q�6�   5[      5\      