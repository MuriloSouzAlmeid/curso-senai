import { StatusBar } from 'expo-status-bar';
import { Image, Modal, StyleSheet, Text, TouchableOpacity, View } from 'react-native';

import { Camera, CameraType } from 'expo-camera';
import { useEffect, useState, useRef } from 'react';

import { AntDesign, FontAwesome } from '@expo/vector-icons';

import * as MediaLibrary from 'expo-media-library'

export default function App() {

  const [tipoCamera, setTipoCameta] = useState(CameraType.back)
  const [openModal, setOpenModal] = useState(false)
  const [foto, setFoto] = useState(null)

  const cameraRef = useRef(null)

  useEffect(() => {
    (async () => {
      const { status: cameraStatus } = await Camera.requestCameraPermissionsAsync()
      const { status: mediaStatus } = await MediaLibrary.requestPermissionsAsync()
    })();
  }, [])

  const CaptureFoto = async () => {

    if (cameraRef) {
      const photo = await cameraRef.current.takePictureAsync()

      setOpenModal(true)
      setFoto(photo.uri)


      console.log(photo);
    }
  }

  const ClearFoto = async () => {
    setFoto(null)
    setOpenModal(false)
  }

  const UploadFoto = async () => {
    await MediaLibrary.createAssetAsync(foto)
      .then(() => {
        console.warn("Foto salva com sucesso cabaço")
      }).catch(error => {
        alert("Não foi possível salvar a foto")
      })
  }

  return (
    <View style={styles.container}>
      <Camera
        ref={cameraRef}
        style={styles.camera}
        ratio='15:9'
        type={tipoCamera}
      >
        <View
          style={styles.viewFlip}
        >
          <TouchableOpacity
            style={styles.btnFlip}
            onPress={() => setTipoCameta(tipoCamera == CameraType.front ? CameraType.back : CameraType.front)}
          >
            <Text Style={styles.txtFlip}>Trocar</Text>
          </TouchableOpacity>
        </View>
      </Camera>

      <TouchableOpacity
        style={styles.btnCapture}
        onPress={CaptureFoto}
      >
        <AntDesign name="camera" size={50} color="black" />
      </TouchableOpacity>

      <Modal
        animationType='slide'
        transparent={false}
        visible={openModal}
      >
        <View
          style={{ flex: 1, margin: 20, justifyContent: "center", alignItems: "center" }}
        >
          {/* Controles da foto */}
          <View
            style={{ margin: 10, flexDirection: "row", gap: 20 }}
          >
            <TouchableOpacity
              style={styles.btnClear}
              onPress={() => ClearFoto()}
            >
              <FontAwesome name="trash" size={24} color="red" />
            </TouchableOpacity>
            <TouchableOpacity
              style={styles.btnUpload}
              onPress={() => UploadFoto()}
            >
              <FontAwesome name="upload" size={24} color="darkgreen" />
            </TouchableOpacity>
          </View>

          <Image
            style={{ width: "100%", height: 500, borderRadius: 15 }}
            source={{ uri: foto }}
          />
        </View>
      </Modal>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  camera: {
    height: "80%",
    width: "100%"
  },
  viewFlip: {
    flex: 1,
    backgroundColor: "transparent",
    flexDirection: "row",
    alignItems: "flex-end",
    justifyContent: "center"
  },
  btnFlip: {
    padding: 10,
    backgroundColor: "white",
    borderRadius: 10,
    marginBottom: 15
  },
  txtFlip: {
    fontSize: 20,
    marginBottom: 20,
  },
  btnCapture: {
    padding: 20,
    margin: 20,
    borderRadius: 10,
    backgroundColor: "#8775F0",
    justifyContent: "center",
    alignItems: "center"
  },
  btnCapture: {
    padding: 20,
    backgroundColor: "#transparent",

    justifyContent: "center",
    alignItems: "center"
  }
});
