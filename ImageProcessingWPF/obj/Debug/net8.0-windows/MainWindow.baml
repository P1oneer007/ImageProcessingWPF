   M S B A M L   `   `   `  ����M  IImageProcessingWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ImageProcessingWPFImageProcessingWPF  5   	   #    ImageProcessingWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ImageProcessingWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��0��5      $��0��6!   $��
Load Image��6.   6C   �� 5   
   -   5        $��0��5      $��1��6!   $��Load Image by OpenCV��6.   6M   �� 5   
   -   5        $��1��5      $��0��6!   $��	Normalize��6.   6B   �� 5   
   -   5        $��1��5      $��1��6!   $��Gamma Correction��6.   6I   �� 5    
   -   5        $��1��5       $��2��6!   $��Invert��6.   6?   �� 5!   
   -   5        $��1��5!      $��3��6!   $��Histogram Equalization��6.   6O   �� 5#   
   -   5        $��1��5#      $��4��6!   $��Median Filter��6.   6F   �� 5$   
   -   5        $��1��5$      $��5��6!   $��
Box Filter��6.   6C   �� 5%   
   -	   5        $��1��5%      $��6��6!   $��Bilateral Filter��6.   6I   �� 5&   
   -
   5        $��1��5&      $��7��6!   $��Gaussian Filter��6.   6H   �� 5'   
   -   5        $��1��5'      $��8��6!   $��Sharpen Filter��6.   6G   �� 5)   
   -   5        $��	ImageView��5)   >   $��0��6   $��2��6    $��7��6-   $��UniformToFill=�6O   5*      5+      