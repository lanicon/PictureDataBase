   M S B A M L   `   `   `  ����@  <PicDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PicDBPicDB  5   	   clr-namespace:PicDBPicDB  5   	   3clr-namespace:PicDB.ViewModelsPicDB.ViewModels  5   	       PicDB.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'controlclr-namespace:PicDB     5   	   %localclr-namespace:PicDB     5   	   5
viewmodelsclr-namespace:PicDB.ViewModels     5   	     � Title$  
MainWindow��5
   	   $	��800��6   $
��1200��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��41 �6   �� 5      $��3* �6   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   �� .+�5      o� $	��Top=�6   ��5      �� 5      .R�5      ]� $��Stretch=�6$   5      .@�5       m� $
��File��6   $��	20 3 20 3q�6)   .@�5!      m� $��_Open��6   m� 5"      $��_Close��6   m� 5#      $��_Save��6   5$      m� 5%      $
��Edit��6   $��	20 3 20 3q�6)   .@�5&      m� $��_Open��6   m� 5'      $��_Close��6   m� 5(      $��_Save��6   5)      m� 5*      $��Options��6   $��	20 3 20 3q�6,   .@�5+      m� $��_Open��6   m� 5,      $��_Close��6   m� 5-      $��_Save��6   5.      m� 5/      $
��Help��6   $��Right=�6)   $��	20 3 20 3q�6E   .@�50      m� $��_Open��6   m� 51      $��_Close��6   m� 52      $��_Save��6   53      54      �� 56      -   5        $
��test��56      $��0 0 0 1q�57      
���������59      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�.��5:   7   5;      5<      � 5>   
   $��1��6    � ColumnDefinitions 5?      �� 5@      $	��30* �6#   $	��500��6/   �� 5A      $
��470* �6#   �� 5B      $
��861* �6#   �� 5C      $��5 �6#   �� 5D      $
��274* �6#   $	��200��60   .+�5G      �� $��0��6O   $	��350��6_   $��4��6l   $��0,97,4.6,96.2q�6�   ��6   �� *SelectedItem.FileName+ �� ElementName$
 list��6�   �� 5I      $��3��6   $��5��6+   $��Stretch=�65   $��2��6S   $��0.2,0,273.2,0.2q�6g   �� 5K      $��4��6   $��0.4,0,-0.8,0.2q�6)   .@�5L      �� $
��IPTC��6   .��5M      �� .+�5N      �� $
��Bold"�6    .��62   
Headline6<   �� 5O      $	��5 0q�5P   "   $��2q�6/   ��5O   "   �� *%#SelectedItem.IptcViewModel.Headline+$
 list�� �� Mode$ TwoWay=�5P   /   �� 5R      $
��Bold"�6    .��62   	Caption6;   �� 5S      $	��5 0q�5T   "   $��2q�6/   ��5S   "   �� *$"SelectedItem.IptcViewModel.Caption+$
 list��$ TwoWay=�5T   /   �� 5V      $
��Bold"�6    .��62   City68   �� 5W      $	��5 0q�5X   "   $��2q�6/   ��5W   "   �� *!SelectedItem.IptcViewModel.City+$
 list��$ TwoWay=�5X   /   �� 5Z      $��50��6!   $
��5 15q�6,   $
��Left=�6:   ��6U   �� *(&SelectedItem.IptcViewModel.SaveCommand+$
 list��.��6�   Save5\      5]      5^      �� 5_      $
��EXIF��6   .��5`      �� .+�5a      �� $
��Bold"�6    .��62   Camera Model6@   �� 5b      $	��5 0q�5c   *   $��2q�67   $��0q�6C    �� 
IsReadOnly . ��5b   "   �� *,*SelectedItem.ExifViewModel.ExifCameraModel+$
 list��$ OneWay=�5c   W   �� 5e      $
��Bold"�6    .��62   
F-Number6<   �� 5f      $	��5 0q�5g   *   $��2q�67   $��0q�6C    . ��5f   "   �� *$"SelectedItem.ExifViewModel.FNumber+$
 list��$ OneWay=�5g   W   �� 5i      $
��Bold"�6    .��62   Exposure Time6A   �� 5j      $	��5 0q�5k   *   $��2q�67   $��0q�6C    . ��5j   "   �� *)'SelectedItem.ExifViewModel.ExposureTime+$
 list��$ OneWay=�5k   W   �� 5m      $
��Bold"�6    .��62   
Date Taken6>   �� 5n      $	��5 0q�5o   *   $��2q�67   $��0q�6C    . ��5n   "   �� *%#SelectedItem.ExifViewModel.DateTime+$
 list��$ OneWay=�5o   W   �� 5q      $
��Bold"�6    .��62   Photgrapher6?   �� 5r      $	��5 0q�5s   *   $��2q�67   $��0q�6C    . ��5r   "   �� *-+SelectedItem.PhotographerViewModel.FullName+$
 list��$ OneWay=�5s   W   5t      5u      �� 5v      $��Photographers��6   .��5w      �� .+�5x      �� -   5        $��photographers��5x   #   $��5q�68   ��6C   �� *photographerViewModels+��5y      �� 5z   "   .R�5{   &   �� ��63   �� *
FullName+6R   5|   #   5~      �� 5�      $
��Bold"�6    .��62   
First Name6>   �� 5�      $	��5 0q�5�   "   $��2q�6/   ��5�   "   �� *SelectedItem.firstNameColor+$ photographers��$ OneWay=���6~   �� *SelectedItem.FirstName+$ photographers��$ TwoWay=�5�   /   �� 5�      $
��Bold"�6    .��62   	Last Name6=   �� 5�      $	��5 0q�5�   "   $��2q�6/   ��5�   "   �� *SelectedItem.lastNameColor+$ photographers��$ OneWay=���6}   �� *SelectedItem.LastName+$ photographers��$ TwoWay=�5�   /   �� 5�      $
��Bold"�6    .��62   
Birthday6<   �� 5�       �� Orientation$ 
Horizontal=�6%   .+�5�      �� .��6$   Day:6*   �� 5�      $��50��6�   ��6'   �� *SelectedItem.birthdayColor+$ photographers��$ OneWay=���6�   �� *SelectedItem.BirthdayDay+$ photographers��$ TwoWay=�6�   �� 5�      .��6$   Month:6,   �� 5�      $��50��6�   ��6&   �� *SelectedItem.birthdayColor+$ photographers��$ OneWay=���6�   �� *SelectedItem.BirthdayMonth+$ photographers��$ TwoWay=�6�   �� 5�      .��6$   Year:6+   �� 5�      $��50��6�   ��6&   �� *SelectedItem.birthdayColor+$ photographers��$ OneWay=���6�   �� *SelectedItem.BirthdayYear+$ photographers��$ TwoWay=�6�   5�      �� 5�      $
��Bold"�6    .��62   Notes69   �� 5�      $	��5 0q�5�   "   $��2q�6/   ��5�   "   �� *SelectedItem.Notes+$ photographers��$ TwoWay=�5�   /   �� 5�      $��50��6!   $
��5 15q�6,   $
��Left=�6:   ��6U   �� *SelectedItem.SaveCommand+$ photographers��.��6�   Save5�      5�      5�      �� 5�      $��Add Photographer��6   .��5�      �� .+�5�      �� $
��Bold"�6    .��62   
First Name6>   �� 5�      $	��5 0q�5�   "   $��2q�6/   ��5�   "   �� * AddPhotographer.firstNameColor+$ OneWay=���6f   �� *AddPhotographer.FirstName+$ TwoWay=�5�   /   �� 5�      $
��Bold"�6    .��62   	Last Name6=   �� 5�      $	��5 0q�5�   "   $��2q�6/   ��5�   "   �� *AddPhotographer.lastNameColor+$ OneWay=���6e   �� *AddPhotographer.LastName+$ TwoWay=�5�   /   �� 5�      $
��Bold"�6    .��62   
Birthday6<   �� 5�      $ 
Horizontal=�6%   .+�5�      �� .��6$   Day6)   �� 5�      $��50��6&   $	��5 0q�5�   "   $��2q�6/   ��5�   1   �� *AddPhotographer.birthdayColor+$ OneWay=���6t   �� *AddPhotographer.BirthdayDay+$ TwoWay=�5�   /   �� 5�      .��6$   Month6+   �� 5�      $��50��6&   $	��5 0q�5�   "   $��2q�6/   ��5�   1   �� *AddPhotographer.birthdayColor+$ OneWay=���6t   �� *AddPhotographer.BirthdayMonth+$ TwoWay=�5�   /   �� 5�      .��6$   Year6*   �� 5�      $��50��6&   $	��5 0q�5�   "   $��2q�6/   ��5�   1   �� *AddPhotographer.birthdayColor+$ OneWay=���6t   �� *AddPhotographer.BirthdayYear+$ TwoWay=�5�   /   5�      �� 5�      $
��Bold"�6    .��62   Notes69   �� 5�      $	��5 0q�5�   "   $��2q�6/   ��5�   "   �� *AddPhotographer.Notes+$ TwoWay=�5�   /   �� 5�      $��50��6!   $
��5 15q�6,   $
��Left=�6:   ��6U   �� *SaveNewCommand+.��6x   Save5�      5�      5�      5�      5�      �� 5�   
   $��2��6   $��5��6$   $��Stretch=�6/   �� 5�   
   -   5        $
��list��5�      $��3��6   ��6,   �� *
pictures+ �� SelectedItem 6M   �� *CurrentPicture+��5�      �� 5�      .R�5�      $� 	 $� Orientation$	 
Horizontal=�6-   5�      ��5�      �� 5�      .R�5�      � .+�5�      �� $	��100��6    ��6,   �� *
FileName+5�      5�      5�      5�      5�      